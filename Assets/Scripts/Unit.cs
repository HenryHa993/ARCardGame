using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public UnityEvent<int> OnDamagedEvent;
    public UnityEvent<int> OnHealedEvent;
    public UnityEvent OnDeathEvent;
    
    public int MaxHealth;
    public int CurrentHealth;
    public int Damage;

    //public bool IsFocused;
    
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Attempt at touch functionality
    /*private void OnMouseDown()
    {
        Debug.Log("hi");
    }

    private void OnMouseExit()
    {
        Debug.Log("bye");
    }*/

    public void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log(name + " took " + damage + " damage");
        Debug.Log(name + " now has " + CurrentHealth + " health");

        if (CurrentHealth <= 0)
        {
            ApplyDeath();
        }
        
        OnDamagedEvent.Invoke(damage);
    }

    public void ApplyHealing(int heal)
    {
        CurrentHealth += heal;
        Debug.Log(name + " healed " + heal + " health");
        Debug.Log(name + " now has " + CurrentHealth + " health");
        
        OnHealedEvent.Invoke(heal);
    }

    public void ApplyDeath()
    {
        Debug.Log(name + " has now died");

        Destroy(gameObject);
        
        OnDeathEvent.Invoke();
    }
}
