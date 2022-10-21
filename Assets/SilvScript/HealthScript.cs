using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth;

    public float damage;
    public float healing;
    public HealthBar healthBar;
    // Define the health changed event and handler delegate.
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);

    // Show in inspector
    [SerializeField]
    float currentHealth;
    // Allow other scripts a readonly property to access current health
    public float CurrentHealth => currentHealth;

    // test values
    [SerializeField]
    float testHealAmount = 5f;
    [SerializeField]
    float testDamageAmount = -5f;

    public void ChangeHealth(float amount)
    {
        float oldHealth = currentHealth;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Fire off health change event.
        healthBar.SetHealth(this, oldHealth, currentHealth);
    }



        // Test code
        void Update()
    {
        curHealth -= damage;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeHealth(testHealAmount);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeHealth(testDamageAmount);
        }
    }

}
