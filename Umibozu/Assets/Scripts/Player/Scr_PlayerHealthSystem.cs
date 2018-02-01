using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_PlayerHealthSystem : MonoBehaviour {

    public Image healthBar;
    public float maxHealth;
    private float currentHealth = 0f;
    private float damage = 0f;
    private float healthRegen = 15.0f;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            damage = 15f;
            TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("Shark"))
        {
            damage = 20f;
            TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("HealthPack") && currentHealth != maxHealth)
        {
            other.gameObject.SetActive(false);
            RegenHealth(healthRegen);
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        float calcHealth = currentHealth / maxHealth; //Calculate % of maxHealth for UI
        SetHealth(calcHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //TODO: Play death animation
            TriggerLoss();
        }
    }

    void RegenHealth(float regenAmount)
    {
        currentHealth += regenAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        float calcHealth = currentHealth / maxHealth; //Calculate % of maxHealth for UI
        SetHealth(calcHealth);
    }

    void SetHealth(float myHealth)
    {
        healthBar.fillAmount = myHealth;
    }

    void TriggerLoss()
    {
        //TODO: Change to loss scene
    }
}
