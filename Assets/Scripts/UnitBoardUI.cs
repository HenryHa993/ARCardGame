using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitBoardUI : MonoBehaviour
{
    public Unit Unit;
    
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Damage;

    private void Start()
    {
        Unit.OnDamagedEvent.AddListener(SetHealth);
        Unit.OnHealedEvent.AddListener(SetHealth);
        
        SetupUnitBoardUI();
    }

    public void SetupUnitBoardUI()
    {
        Health.SetText("" + Unit.MaxHealth);
        Damage.SetText("" + Unit.Damage);
    }

    public void SetHealth(int health)
    {
        Health.SetText("" + Unit.CurrentHealth);
    }
    
    public void SetDamage(int damage)
    {
        Health.SetText("" + Unit.Damage);
    }
}
