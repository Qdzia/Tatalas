﻿using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Entity owner;
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
   

    public Stat armor;
    public Stat damage;
    public Stat speed;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {

        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");
       
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        owner.Die();
    }
}


