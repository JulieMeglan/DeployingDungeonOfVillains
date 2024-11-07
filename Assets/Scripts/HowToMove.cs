using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToMove : MonoBehaviour
{
    private bool target;

    public static string BLOCKING_LAYER_MASK = "Blocking";

    [SerializeField] protected float xSpeed = 1.1f, ySpeed = 0.74f;

    private RaycastHit2D hit;

    private Vector3 deltaMotion;

    private BoxCollider2D myCollider;

    public bool HasPlayerTarget {
        get => target;
        set => target = value;
    }

    protected virtual void Awake() {
        myCollider = GetComponent<BoxCollider2D>();
    }
    
    protected virtual void HandleMovement(float x, float y) {

        deltaMotion = new Vector3(x * xSpeed, y * ySpeed, 0f);
        hit = Physics2D.BoxCast(transform.position, myCollider.size, 0f, new Vector2(0f, deltaMotion.y), Mathf.Abs(deltaMotion.y * Time.deltaTime), LayerMask.GetMask(BLOCKING_LAYER_MASK));

        if (hit.collider == null) {
            transform.Translate(0f, deltaMotion.y * Time.deltaTime, 0f);
        }

        hit = Physics2D.BoxCast(transform.position, myCollider.size, 0f, new Vector2(deltaMotion.x, 0f), Mathf.Abs(deltaMotion.x * Time.deltaTime), LayerMask.GetMask(BLOCKING_LAYER_MASK));

        if (hit.collider == null) {
            transform.Translate(deltaMotion.x * Time.deltaTime, 0f, 0f);
        }
    }

    public Vector3 GetMoveDelta() {
        return deltaMotion;
    }
    
}


































