using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : HowToMove
{

    public static string HORIZONTAL_AXIS = "Horizontal";
    public static string VERTICAL_AXIS = "Vertical";
    
    public static string FACE_X_ANIMATION_PARAMETER = "FaceX";
    public static string FACE_Y_ANIMATION_PARAMETER = "FaceY";
    private float transitionX, transitionY;

    private Camera mainCam;

    private Vector2 cursor;
    private Vector2 direction;
    private Vector3 size;

    private Animator anim;

    private characterGunController characterGunController;

    private HealthStatus characterHealthStatus;

    protected override void Awake() {
        base.Awake();

        mainCam = Camera.main;
        anim = GetComponent<Animator>();
        characterGunController = GetComponent<characterGunController>();
    }

    private void Start() {
        characterHealthStatus = GetComponent<HealthStatus>();
    }

    private void FixedUpdate() {

        if (!characterHealthStatus.IsAlive()) { // if dead return so can't move
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverYouLost");
            return;
        }

        transitionX = Input.GetAxisRaw(HORIZONTAL_AXIS);
        transitionY = Input.GetAxisRaw(VERTICAL_AXIS);

        Turning();
        HandleMovement(transitionX, transitionY);
    }

    void Turning() {
        cursor = mainCam.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(cursor.x - transform.position.x, cursor.y - transform.position.y).normalized;
        Animation(direction.x, direction.y);
    }

    void Animation(float x, float y) {

        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);

        size = transform.localScale;

        if (x > 0) {
            size.x = Mathf.Abs(size.x);
        }
        else if(x < 0) {
            size.x = -Mathf.Abs(size.x);
        }

        transform.localScale = size;

        x = Mathf.Abs(x);

        anim.SetFloat(FACE_X_ANIMATION_PARAMETER, x);
        anim.SetFloat(FACE_Y_ANIMATION_PARAMETER, y);

        ChangeWeaponDirection(x, y);
    }


    void ChangeWeaponDirection(float x, float y) {
    string key = $"{x},{y}";

    switch (key) {
        case "1,0":
            characterGunController.ActivateGun(0); // side
            break;
        case "0,1":
            characterGunController.ActivateGun(1); // up
            break;
        case "0,-1":
            characterGunController.ActivateGun(2); // down
            break;
        case "1,1":
            characterGunController.ActivateGun(3); // side up
            break;
        case "1,-1":
            characterGunController.ActivateGun(4); // side down
            break;
        default:
            characterGunController.ActivateGun(1); // default = up
            break;
        }
    }
}


































