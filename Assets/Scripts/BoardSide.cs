using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardSide : MonoBehaviour
{
    public Unit BoardUnit;
    public Canvas Arrow;
    public Fade AttackPosition;
    public Fade AttackArrow;
    public GameObject AttackText;

    public void SetupActionSide()
    {
        Arrow.enabled = true;
        //AttackPosition.SetActive(true);
        
        StartCoroutine(AttackPosition.FadeIn());
        StartCoroutine(AttackArrow.FadeIn());
        AttackText.SetActive(true);

        //AttackPosition.SetActive(true);
    }
    
    public void SetupDefendSide()
    {
        Arrow.enabled = false;
        //AttackPosition.SetActive(false);
        StartCoroutine(AttackPosition.FadeOut());
        StartCoroutine(AttackArrow.FadeOut());
        AttackText.SetActive(false);

        //AttackPosition.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // todo: disallow card changes when not player turn
        Debug.Log(other.name + " entered " + name);
        BoardUnit = other.gameObject.GetComponent<Unit>();
        
        if (BoardUnit == null)
        {
            return;
        }
        
        BoardUnit.SetUnitActive();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " left " + name);
        BoardUnit = null;
    }
    
}
