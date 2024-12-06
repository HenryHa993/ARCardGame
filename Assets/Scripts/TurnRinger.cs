using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*Finishes the turn.*/
public class TurnRinger : MonoBehaviour
{
    public Board OwningBoard;

    private void OnTriggerEnter(Collider other)
    {
        Unit instigaterUnit = other.gameObject.GetComponent<Unit>();
        
        if (instigaterUnit == null)
        {
            Debug.Log("Nope.");
            return;
        }   
        if (instigaterUnit != OwningBoard.ActionSide.BoardUnit)
        {
            Debug.Log("Not player turn.");
            return;
        }
        
        OwningBoard.OnEndTurn();
    }
}
