using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoardState
{
    BlueTurn,
    RedTurn
}

public class Board : MonoBehaviour
{
    public BoardSide ActionSide;
    public BoardSide DefendSide;

    public BoardState CurrentState;

    private void Start()
    {
        CurrentState = BoardState.BlueTurn;
        ActionSide.Arrow.enabled = true;
        DefendSide.Arrow.enabled = false;
    }

    public void OnEndTurn()
    {
        if (ActionSide.BoardUnit == null || DefendSide.BoardUnit == null)
        {
            return;
        }
        
        Debug.Log(ActionSide.name + " attacks " + DefendSide.name);
        TurnAction();
        
        (ActionSide, DefendSide) = (DefendSide, ActionSide);
        ActionSide.Arrow.enabled = true;
        DefendSide.Arrow.enabled = false;
    }

    public void TurnAction()
    {
        ActionSide.Attack(DefendSide);
    }
}
