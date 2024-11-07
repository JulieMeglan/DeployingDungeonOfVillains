using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform targetPosition;
    public static string PLAYER_TAG = "Player";


    [SerializeField] private float xConstraint = 0.3f, yConstraint = 0.14f;

    private Vector3 positionDelta;

    private float xDelta, yDelta;

    private void Start() {
        targetPosition = GameObject.FindWithTag(PLAYER_TAG).transform;
    }

    private void LateUpdate() {

        if (!targetPosition) {
            return;
        }

        positionDelta = Vector3.zero;
        xDelta = targetPosition.position.x - transform.position.x;

        if (xDelta > xConstraint || xDelta < -xConstraint) {

            if (transform.position.x < targetPosition.position.x) {
                positionDelta.x = xDelta - xConstraint;
            }
            else {
                positionDelta.x = xConstraint + xDelta;
            }
        }

        yDelta = targetPosition.position.y - transform.position.y;

        if (yDelta > yConstraint || yDelta < -yConstraint) {

            if (transform.position.y < targetPosition.position.y) {
                positionDelta.y = yDelta - yConstraint;
            }
            else {
                positionDelta.y = yConstraint + yDelta;
            }
        }

        positionDelta.z = 0f;
        transform.position += positionDelta;
    }
} 




