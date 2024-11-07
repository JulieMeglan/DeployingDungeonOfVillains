using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterGunController : MonoBehaviour
{

    [SerializeField] private GunController[] playerWeapons;

    private int gunIndex;

    [SerializeField] private GameObject[] weaponBullets;

    private Camera mainCam;

    private Vector2 aim;

    private Vector2 direction;


    private Vector2 projectileLine;

    private Quaternion projectileMovement;


    private void Awake() {
        gunIndex = 0;
        playerWeapons[gunIndex].gameObject.SetActive(true);

        mainCam = Camera.main;

    }

    private void Update() {
        SwitchGun();
    }

    public void ActivateGun(int weaponIndex) {
        playerWeapons[this.gunIndex].EnableWeapon(weaponIndex);
    }

    void SwitchGun() {
        if (Input.GetKeyDown(KeyCode.N)) {
            playerWeapons[gunIndex].gameObject.SetActive(false);

            gunIndex++;

            if (gunIndex == playerWeapons.Length) {
                gunIndex = 0;
            }

            playerWeapons[gunIndex].gameObject.SetActive(true);
        }
    }

    public void Fire(Vector3 initialPosition) {

        aim = mainCam.ScreenToWorldPoint(Input.mousePosition);

        projectileLine = new Vector2(initialPosition.x, initialPosition.y);

        direction = (aim - projectileLine).normalized;

        projectileMovement = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        ProjectilePool.instance.FireBullet(gunIndex, initialPosition, projectileMovement, direction);
        GameObject newBullet = Instantiate(weaponBullets[gunIndex], initialPosition, projectileMovement);
        newBullet.GetComponent<Projectile>().ProjectileMovement(direction);


    }

}




