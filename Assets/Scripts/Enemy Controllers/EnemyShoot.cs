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

    AudioSource myAudio;
    public AudioClip spit;
    public float volume;
    
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting == true)
        {
            timer += Time.deltaTime;

            if(timer >= 2)
            {
                myAudio.PlayOneShot(spit, volume);
            }

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
