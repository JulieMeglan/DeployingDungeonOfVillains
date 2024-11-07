using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishTrigger : MonoBehaviour
{
    public static string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG)) {
            SceneManager.LoadScene("Level1Complete");
        }
    }
}
