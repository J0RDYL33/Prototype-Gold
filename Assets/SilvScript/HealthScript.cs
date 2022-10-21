using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth;

    public float damage;
    public float healing;
    // Define the health changed event and handler delegate.
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
    public event HealthChangedHandler OnHealthChanged;

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
        OnHealthChanged?.Invoke(this, oldHealth, currentHealth);
    }

    // Test code
    void Update()
    {
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
