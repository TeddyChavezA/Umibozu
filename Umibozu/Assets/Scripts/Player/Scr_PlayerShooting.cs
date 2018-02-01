using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerShooting : MonoBehaviour {

    float fireRate = 0;
    float fireTime = 0;
    public float damage = 1;
    public LayerMask whatToHit;
    public Transform firePoint;

    public GameObject projectilePrefab;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.Find("Obj_Archer");
        if (firePoint == null)
        {
            Debug.LogError("Error: No firepoint found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > fireTime)
            {
                fireTime = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);


        //Raycast firing
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, (mousePosition - firePointPosition), 100, whatToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
       Debug.Log(hit.collider.name + " was hit for " + damage + " damage.");
    }

    void SpawnProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

}
