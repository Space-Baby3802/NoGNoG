using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float health;
    public bool isDead {  get; private set; }

    public Action<float> onHealthChange;
    public Action onDeath;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        onHealthChange(maxHealth);
    }

    public void DeductHealth(float value)
    {
        if (isDead) return;

        health -= value;
        if (health <= 0)
        {
            isDead = true;
            onDeath();
            health = 0;
        }

        onHealthChange(health);
    }
}
