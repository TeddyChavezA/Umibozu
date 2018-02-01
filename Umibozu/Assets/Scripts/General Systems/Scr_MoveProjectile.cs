using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MoveProjectile : MonoBehaviour {

    public int moveSpeed;
    private Transform direction; 

    // Update is called once per frame
    void Update()
    {
        Vector3 arrowPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Quaternion rot = transform.rotation;

        if (rot.z < 45 && rot.z >= 315) //Shoot up
        {
            direction = Vector3();
        }
        if (rot.z >= 45 && rot.z < 135) //Shoot left
        {
            transform.Translate(-transform.right * Time.deltaTime * moveSpeed);
        }
        if (rot.z >= 135 && rot.z < 225) //Shoot down
        {
            transform.Translate(-transform.up * Time.deltaTime * moveSpeed);
        }
        if (rot.z >= 225 && rot.z < 315) //Shoot right
        {
            transform.Translate(transform.right * Time.deltaTime * moveSpeed);
        }

        transform.Translate(transform.right * Time.deltaTime * moveSpeed);


        //Destroy projectiles outside of screen
        if (arrowPos.y >= Screen.height || arrowPos.y <= 0 
            || arrowPos.x >= Screen.width || arrowPos.x <= 0)
        {
            DestroyObject(gameObject);
        }
    }
}
