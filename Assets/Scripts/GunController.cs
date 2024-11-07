using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] private GameObject[] guns;

    private int activeWEapon;


    private void Start() {
        DisableWeapons();
    }

    void DisableWeapons() {
        for (int i = 0; i < guns.Length; i++)
            guns[i].SetActive(false);
    }

    public void EnableWeapon(int updateWeaponIndex) {
        
        guns[activeWEapon].SetActive(false);
        guns[updateWeaponIndex].SetActive(true);
        
        activeWEapon = updateWeaponIndex;
    }


}





