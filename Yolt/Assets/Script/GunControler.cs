using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControler : MonoBehaviour {

    public Transform bulletTra;
    public bool isFiring;
    public BulletControler bullet;
    public float bulletSpeed;
    public float TimeBetweenShots;
    private float shotCounter;
    public Transform firepoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = TimeBetweenShots;
                BulletControler newBullet = Instantiate(bullet, firepoint.position, bulletTra.rotation) as BulletControler;
                newBullet.transform.LookAt(bulletTra.GetComponent<Movement>().Pointtolook());
                newBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed);
                Destroy(newBullet);
            }
        }
        else
        {
            shotCounter = 0;
        }

    }
}
