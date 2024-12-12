using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum BoardState
{
    BlueTurn,
    RedTurn
}*/

public class Board : MonoBehaviour
{
    public BoardSide ActionSide;
    public BoardSide DefendSide;
    private Quaternion DefaultRotation;

    public Unit Attacker;
    
    //public BoardState CurrentState;

    private IEnumerator Start()
    {
        DefaultRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        yield return new WaitForEndOfFrame();
        
        ActionSide.SetupActionSide();
        DefendSide.SetupDefendSide();
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, transform.parent.transform.transform.rotation.eulerAngles.y, 0);
    }

    public void OnEndTurn()
    {
        if (DefendSide.BoardUnit == null)
        {
            return;
        }
        
        Debug.Log(ActionSide.name + " attacks " + DefendSide.name);
        TurnAction();
        SwapSides();
    }

    private void TurnAction()
    {
        //Unit actionUnit = ActionSide.BoardUnit;
        Unit defendUnit = DefendSide.BoardUnit;

        //Attacker.Attack(defendUnit);
        StartCoroutine(Attacker.Attack(defendUnit));
        //ActionSide.Attack(DefendSide);
    }

    private void SwapSides()
    {
        (ActionSide, DefendSide) = (DefendSide, ActionSide);
        ActionSide.SetupActionSide();
        DefendSide.SetupDefendSide();
    }
}
