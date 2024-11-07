using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static string EXPLODE_ANIMATION_PARAMETER = "Explode";
    public static string ENEMY_TAG = "Enemy";

    public static string BLOCKING_TAG = "Blocking";

    private Rigidbody2D myBody;

    [SerializeField]
    private float speed = 2.5f;

    [SerializeField]
    private float injuryValue = 25f;

    private bool hitsIncurred;

    [SerializeField]
    private float disableCountdown = 3f;

    [SerializeField]
    private bool destroyObj;

    private Animator animator;

    private SpriteRenderer sprite;

    private Sprite projectileGraphic;

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();
        projectileGraphic = sprite.sprite;
    }

    private void OnDisable() {
        myBody.velocity = Vector2.zero;
    }
    private void OnEnable() {
        animator.SetBool(EXPLODE_ANIMATION_PARAMETER, false);

        animator.enabled = false;
        sprite.sprite = projectileGraphic;
        hitsIncurred = false;

        Invoke("DeactivateBullet", disableCountdown);
    }


    public void ProjectileMovement(Vector3 direction) {
        myBody.velocity = (speed * direction);
    }

    void DeactivateBullet() {
        if (destroyObj) {
            Destroy(gameObject);
        }
        
        else {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag(ENEMY_TAG)) {

            myBody.velocity = Vector2.zero;
            CancelInvoke("DeactivateBullet");

            animator.enabled = true;
            animator.SetBool(EXPLODE_ANIMATION_PARAMETER, true);

            if (!hitsIncurred) {
                hitsIncurred = true;
                collision.GetComponent<HealthStatus>().TakeDamage(injuryValue);
            }

        }

        if (collision.CompareTag(BLOCKING_TAG)) {

            myBody.velocity = Vector2.zero;
            CancelInvoke("DeactivateBullet");

            animator.enabled = true;
            animator.SetBool(EXPLODE_ANIMATION_PARAMETER, true);

        }

    }

} 







