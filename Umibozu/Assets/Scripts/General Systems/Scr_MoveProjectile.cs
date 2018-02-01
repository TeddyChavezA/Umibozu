using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MoveProjectile : MonoBehaviour {

   void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    

}
