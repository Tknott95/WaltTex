using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// if the Fire1 button (default is Ctrl) is pressed.
public class PlayerFire : MonoBehaviour {
    public GameObject projectile;
    public float fireDelta = 0.5F;
    public float shotSpeed = 50;

    public float ammo = 20;
    public Text ammoCount;

    private float nextFire = 0.5F;
    private GameObject newProjectile;
    private float myTime = 0.0F;

    private void Awake()
    {
        ammoCount.text = ammo.ToString();
    }

    void Update()
    {
        myTime = myTime + Time.deltaTime;

        while (ammo > 0)
        {
            if (Input.GetButton("Fire1") && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                newProjectile.GetComponent<Rigidbody>().velocity = newProjectile.transform.forward * shotSpeed;
                ammo--; ;
                ammoCount.text = ammo.ToString();
                // create code here that animates the newProjectile

                nextFire = nextFire - myTime;
                myTime = 0.0F;

                // Destroy the bullet after 2 seconds
                Destroy(newProjectile, 2.0f);
            }
        }
    }
}

