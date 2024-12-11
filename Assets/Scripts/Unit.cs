using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public enum Element
    {
        Rock,
        Paper,
        Scissors
    }

    public Element ElementType;

    private Dictionary<Element, Element> ElementAdvantages = new Dictionary<Element, Element>
    {
        {
            Element.Rock, Element.Scissors
        },
        {
            Element.Paper, Element.Rock
        },
        {
            Element.Scissors, Element.Paper
        },
    };
    
    public UnityEvent<int> OnDamagedEvent;
    public UnityEvent<int> OnHealedEvent;
    public UnityEvent OnDeathEvent;
    
    public int MaxHealth;
    public int CurrentHealth;
    public int Damage;

    public GameObject FocusIndicator;
    public bool IsTracked;
    
    public GameObject Icon;
    public GameObject UnitBody;
    
    private void Start()
    {
        CurrentHealth = MaxHealth;
        Icon.SetActive(true);
        UnitBody.SetActive(false);
    }

    /*private void Awake()
    {
        throw new NotImplementedException();
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

    public void Attack(Unit unit)
    {
        Element defendingType = unit.ElementType;

        if (ElementType == defendingType)
        {
            unit.ApplyDamage(Damage);
        }
        else if (ElementAdvantages[ElementType] == defendingType)
        {
            unit.ApplyDamage(2*Damage);
        }
        else
        {
            unit.ApplyDamage((int)(0.5 * Damage));
        }
    }
    
    public void SetUnitActive()
    {
        Icon.SetActive(false);
        UnitBody.SetActive(true);
    }
}
