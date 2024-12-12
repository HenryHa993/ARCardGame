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

    public Animator UnitAnimator;
    
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
        // Apply at least one damage
        if (damage == 0)
        {
            damage = 1;
        }
        
        CurrentHealth -= damage;
        Debug.Log(name + " took " + damage + " damage");
        Debug.Log(name + " now has " + CurrentHealth + " health");

        OnDamagedEvent.Invoke(damage);
        
        if (CurrentHealth <= 0)
        {
            StartCoroutine(ApplyDeath());
            return;
        }
        
        UnitAnimator.SetTrigger("PlayHit");
        
    }

    public void ApplyHealing(int heal)
    {
        CurrentHealth += heal;
        Debug.Log(name + " healed " + heal + " health");
        Debug.Log(name + " now has " + CurrentHealth + " health");
        
        OnHealedEvent.Invoke(heal);
    }

    public IEnumerator ApplyDeath()
    {
        Debug.Log(name + " has now died");
        UnitAnimator.SetTrigger("PlayDeath");
        yield return null;
        
        while ((UnitAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.95f) // Can change this so it looks like it happens on impact instead of on finish
        {
            Debug.Log("Animation ongoing");
            yield return null;
        }
        OnDeathEvent.Invoke();
        Destroy(gameObject);
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

    public IEnumerator Attack(Unit unit)
    {
        Element defendingType = unit.ElementType;

        // Damage potentially needs to be delayed to look nicer
        UnitAnimator.SetTrigger("PlayAttack");
        yield return null;
        
        while ((UnitAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.95f)
        {
            Debug.Log("Animation ongoing");
            yield return null;
        }
        
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
