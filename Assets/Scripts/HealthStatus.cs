using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatus : MonoBehaviour
{
    public static string DEATH_ANIMATION_PARAMETER = "Death";
    public static string PLAYER_TAG = "Player";

    public Slider healthBar;

    private float maximumHealth = 80;
    private float healthStatus;
    private Animator animiation;
    
    private void Awake() {
        animiation = GetComponent<Animator>();
    }

    private void Start() {
        
        healthStatus = maximumHealth; 
        if (healthBar != null) {
            healthBar.maxValue = maximumHealth;
            healthBar.value = healthStatus;
        }
    }

    public void TakeDamage(float damageAmount) {
        healthStatus -= damageAmount;

        if (healthBar != null) {
            healthBar.value = healthStatus;
        }

        if (healthStatus <= 0) {
            if (CompareTag(PLAYER_TAG)) {
                // if player dies
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverYouLost");
            } else {
                // villains die
                gameObject.SetActive(false);
            }
        }
    }

    private void DestroyCharacter() {
        Destroy(gameObject);
    }

    public bool IsAlive() {
        if (healthStatus > 0) {
            return true;
        }
        
        else {
            return false; 
        }
    }
}
