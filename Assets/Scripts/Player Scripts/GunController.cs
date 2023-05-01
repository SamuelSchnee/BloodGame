using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector2 mousePos;
    public GameObject spawnPoint;
    public float bulletSpeed;

    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Fire();
        }

        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
    }

    private void Fire()
    {
        Vector2 spawnPos = spawnPoint.transform.position;
        mousePos = Camera.main.ScreenToWorldPoint (new Vector3(mouseX, mouseY, 0));
        Quaternion rot = bulletPrefab.transform.rotation;

        Debug.Log("spawn bullet");
        GameObject bulletInst = Instantiate(bulletPrefab, spawnPos, rot);

        Rigidbody2D bulletBody = bulletInst.GetComponent<Rigidbody2D>();

        Vector2 launchDirection = mousePos - spawnPos;
        launchDirection.Normalize();

        launchDirection *= bulletSpeed;

        bulletBody.AddForce(launchDirection, ForceMode2D.Impulse);
        Debug.Log("bullet spawned");
    }
}
