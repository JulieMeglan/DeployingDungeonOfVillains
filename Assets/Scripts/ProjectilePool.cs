using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{

    public static ProjectilePool instance;

    [SerializeField]
    private GameObject[] weaponBullets;

    private List<Projectile> pistolBullets = new List<Projectile>();
    private List<Projectile> matterBullets = new List<Projectile>();
    private List<Projectile> laserBullets = new List<Projectile>();
    private List<Projectile> flameBullets = new List<Projectile>();

    private bool bulletSpawned;

    private void Awake() 
    {
        if (instance == null) {
            instance = this;
        }
    }

    public void FireBullet(int bulletIndex, Vector3 spawnPosition, Quaternion bulletRotation, Vector2 bulletDirection)
    {
        bulletSpawned = false;
        TakeBulletFromPool(bulletIndex, spawnPosition, bulletRotation, bulletDirection);
    }

    void TakeBulletFromPool(int bulletIndex, Vector3 spawnPosition, Quaternion bulletRotation, Vector2 bulletDirection)
    {

        if (bulletIndex == 0)
        {
            for (int i = 0; i < pistolBullets.Count; i++) {
                if (!pistolBullets[i].gameObject.activeInHierarchy) {
                    pistolBullets[i].gameObject.SetActive(true);
                    pistolBullets[i].gameObject.transform.position = spawnPosition;
                    pistolBullets[i].gameObject.transform.rotation = bulletRotation;
                    pistolBullets[i].ProjectileMovement(bulletDirection);

                    bulletSpawned = true;
                    break;
                }
            }
        }

        if (bulletIndex == 1)
        {
            for (int i = 0; i < matterBullets.Count; i++) {
                if (!matterBullets[i].gameObject.activeInHierarchy) {
                    matterBullets[i].gameObject.SetActive(true);
                    matterBullets[i].gameObject.transform.position = spawnPosition;
                    matterBullets[i].gameObject.transform.rotation = bulletRotation;
                    matterBullets[i].ProjectileMovement(bulletDirection);

                    bulletSpawned = true;
                    break;
                }
            }
        }

        if (bulletIndex == 2)
        {
            for (int i = 0; i < laserBullets.Count; i++) {
                if (!laserBullets[i].gameObject.activeInHierarchy) {
                    laserBullets[i].gameObject.SetActive(true);
                    laserBullets[i].gameObject.transform.position = spawnPosition;
                    laserBullets[i].gameObject.transform.rotation = bulletRotation;
                    laserBullets[i].ProjectileMovement(bulletDirection);

                    bulletSpawned = true;
                    break;
                }
            }
        }

        if (bulletIndex == 3)
        {
            for (int i = 0; i < flameBullets.Count; i++) {
                if (!flameBullets[i].gameObject.activeInHierarchy) {
                    flameBullets[i].gameObject.SetActive(true);
                    flameBullets[i].gameObject.transform.position = spawnPosition;
                    flameBullets[i].gameObject.transform.rotation = bulletRotation;
                    flameBullets[i].ProjectileMovement(bulletDirection);

                    bulletSpawned = true;
                    break;
                }
            }
        }

        if (!bulletSpawned) {
            CreateNewBullet(bulletIndex, spawnPosition, bulletRotation,
                bulletDirection);
        }
    }

    void CreateNewBullet(int bulletIndex, Vector3 spawnPosition, Quaternion bulletRotation, Vector2 bulletDirection) {

        GameObject newBullet = Instantiate(weaponBullets[bulletIndex],
            spawnPosition, bulletRotation);

        newBullet.transform.SetParent(transform);
        newBullet.GetComponent<Projectile>().ProjectileMovement(bulletDirection);

        if (bulletIndex == 0)
        {
            pistolBullets.Add(newBullet.GetComponent<Projectile>());
        }

        if (bulletIndex == 1)
        {
            matterBullets.Add(newBullet.GetComponent<Projectile>());
        }

        if (bulletIndex == 2)
        {
            laserBullets.Add(newBullet.GetComponent<Projectile>());
        }

        if (bulletIndex == 3)
        {
            flameBullets.Add(newBullet.GetComponent<Projectile>());
        }

        // switch (bulletIndex)
        // {
        //     case 0:
        //         pistolBullets.Add(newBullet.GetComponent<Projectile>());
        //         break;
        //     case 1:
        //         matterBullets.Add(newBullet.GetComponent<Projectile>());
        //         break;
        //     case 2:
        //         laserBullets.Add(newBullet.GetComponent<Projectile>());
        //         break;
        //     case 3:
        //         flameBullets.Add(newBullet.GetComponent<Projectile>());
        //         break;
        //     default:
        //         Debug.LogWarning("Something wrong w/ bullet index");
        //         break;
        // }


    }
    
} 









