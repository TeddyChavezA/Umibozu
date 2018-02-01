using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_PlayerOilSystem : MonoBehaviour {

    public Image oilMeter;
    public float maxOil;
    public float oilDrain;
    private float currentOil;
    private float oilRefill;
    private Transform spotLight;

	// Use this for initialization
	void Start () {
        currentOil = maxOil;
        InvokeRepeating("DrainOil", 1, 2);
        spotLight = transform.Find("Obj_Spotlight");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OilRefill") && currentOil != maxOil)
        {
            oilRefill = 25.0f;
            RefillOil(oilRefill);
        }
    }

    void DrainOil()
    {
        currentOil -= oilDrain;

        if (currentOil <= 0)
        {
            //TODO: Shutdown spotlight 
            spotLight.gameObject.SetActive(false);
            TriggerLoss();
        }
    }

    void RefillOil(float oilRefill)
    {
        currentOil += oilRefill;

        if (currentOil > maxOil)
        {
            currentOil = maxOil;
        }

        float calcOil = currentOil / maxOil; //Calculate % of maxOil for UI
        SetOil(calcOil);
    }

    void SetOil(float myOil)
    {
        oilMeter.fillAmount = myOil;
    }

    void TriggerLoss()
    {
        //TODO: Change to loss scene
    }
}
