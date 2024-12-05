using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject FocusIndicator;
    public bool IsTracked;
    
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

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

    public void SetIsTracked(bool tracked)
    {
        if (IsTracked == tracked)
        {
            return;
        }

        IsTracked = tracked;

        if (IsTracked)
        {
            FocusIndicator.SetActive(true);
        }
        else
        {
            FocusIndicator.SetActive(false);
        }
    }
}
