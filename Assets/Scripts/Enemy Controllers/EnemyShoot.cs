using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float bulletSpeed;
    private float timer;

    public bool shooting = false;
    public float maxCooldown = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting == true)
        {
            timer += Time.deltaTime;

            if (timer >= maxCooldown)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        var currentBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        currentBullet.GetComponent<Rigidbody2D>().velocity = bulletPos.up * bulletSpeed;
    }
}
