using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProjectileController : MonoBehaviour
{
    public static string SHOOT_ANIMATION_PARAMETER = "Shoot";
     [SerializeField] private AudioSource projectileAudio;

    [SerializeField] private float shootingTimerLimit = 0.25f;
    private float pauseBetweenProjectiles;

    [SerializeField] private Transform projectileLine;

    private Animator projectileAnim;

    private characterGunController characterGunController;

    private void Awake() {
        characterGunController = GetComponent<characterGunController>();
        projectileAnim = projectileLine.GetComponent<Animator>();

    }

    private void Update() {
        Trigger();
    }

    void Trigger() {

        if (Input.GetMouseButtonDown(0)) {
            
            if (Time.time > pauseBetweenProjectiles) {
                pauseBetweenProjectiles = shootingTimerLimit + Time.time;
                projectileAnim.SetTrigger(SHOOT_ANIMATION_PARAMETER);
                characterGunController.Fire(projectileLine.position);
            

            if (projectileAudio != null) {
                projectileAudio.Play(); }
            }
        }
    }
    
    void ActivateProjectile() {
        characterGunController.Fire(projectileLine.position);
    }
    
}


