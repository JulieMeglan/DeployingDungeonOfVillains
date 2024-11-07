 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainGroups : MonoBehaviour
{

    [SerializeField] private List<HowToMove> villains;

    [SerializeField] private GameObject door;

    private void Start() {

        foreach (Transform tr in GetComponentInChildren<Transform>()) {
            if (tr != this) {
                villains.Add(tr.GetComponent<HowToMove>());
            }
        }

    }

    public void TurnOnGoingAfterCharacter() {
        foreach (HowToMove charMovement in villains) {
            charMovement.HasPlayerTarget = true;
        }
    }

    public void TurnOffGoingAfterCharacter(){
        
        foreach (HowToMove charMovement in villains) {
            charMovement.HasPlayerTarget = false;
        }
    }

    public void RemoveVillain(HowToMove villain){
        villains.Remove(villain);
        OpenDoor();
    }


    void OpenDoor(){

        if (villains.Count == 0) {
            if (door) {
                door.SetActive(false);
            }
        }
    }
} 



