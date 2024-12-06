using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardSide : MonoBehaviour
{
    public Unit BoardUnit;
    public Canvas Arrow;
    
    private void OnTriggerEnter(Collider other)
    {
        // todo: disallow card changes when not player turn
        Debug.Log(other.name + " entered " + name);
        BoardUnit = other.gameObject.GetComponent<Unit>();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " left " + name);
        BoardUnit = null;
    }

    // Do I really need to do this in the board level?
    public void Attack(BoardSide defendSide)
    {
        if (BoardUnit == null)
        {
            return;
        }

        defendSide.BoardUnit.ApplyDamage(BoardUnit.Damage);
    }
}
