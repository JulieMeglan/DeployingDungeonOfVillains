 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainGroups : MonoBehaviour
{

    [SerializeField] private List<HowToMove> villains;

    [SerializeField] private GameObject door;

    [SerializeField] private AudioSource doorAudio; 
    [SerializeField] private AudioClip doorOpenSound;

    private float minimumDistance = 0.1f; 
    [SerializeField] private float separationForce = 0.01f;

    private void Start() {

        foreach (Transform tr in GetComponentInChildren<Transform>()) {
            if (tr != this) {
                villains.Add(tr.GetComponent<HowToMove>());
            }
        }

    }

    private void FixedUpdate() {
        MaintainVillainSpacing(); 
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

            if (doorAudio != null && doorOpenSound != null) {
                doorAudio.PlayOneShot(doorOpenSound);
        }
        }


    }

    private void MaintainVillainSpacing() {
        for (int i = 0; i < villains.Count; i++) {
            for (int j = i + 1; j < villains.Count; j++) {
                if (villains[i] != null && villains[j] != null) {
                    Vector3 direction = villains[i].transform.position - villains[j].transform.position;
                    float distance = direction.magnitude;

                    if (distance < minimumDistance) {
                        Vector3 pushDirection = direction.normalized * separationForce;
                        villains[i].transform.position += pushDirection;
                        villains[j].transform.position -= pushDirection;
                    }
                }
            }
        }
    }
}



