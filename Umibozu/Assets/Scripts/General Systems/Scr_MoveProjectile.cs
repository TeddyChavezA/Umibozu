using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MoveProjectile : MonoBehaviour {


    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>());
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    

}
