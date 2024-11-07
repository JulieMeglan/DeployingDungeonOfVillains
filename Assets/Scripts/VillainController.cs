using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VillainController : MonoBehaviour {

    public static string PLAYER_TAG = "Player";


    [SerializeField] private VillainGroups villainGroups;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag(PLAYER_TAG)) {
            
            villainGroups.TurnOnGoingAfterCharacter();

        }
    }

}







