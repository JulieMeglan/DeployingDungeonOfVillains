using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainAnimation : MonoBehaviour
{
    public static string DEATH_ANIMATION_PARAMETER = "Death";

    public static string WALK_ANIMATION_PARAMETER = "Walk";

    private HowToMove movingVillain;
    private Animator animator;


    private void Awake() {
        
        animator = GetComponent<Animator>();
        movingVillain = GetComponent<HowToMove>();
    }

    private void Update() {
        UpdateAnimation();
    }

    void UpdateAnimation() {

        if (movingVillain.GetMoveDelta().magnitude > 0.0f) {
            animator.SetBool(WALK_ANIMATION_PARAMETER, true);
        }
        
        else {
            animator.SetBool(WALK_ANIMATION_PARAMETER, false);
        }
    }
    public void DeathAnimation() {

        gameObject.SetActive(false);

    }

} 





