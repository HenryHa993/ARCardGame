using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*Finishes the turn.*/
public class TurnRinger : MonoBehaviour
{
    public Board OwningBoard;
    private IEnumerator CountdownCoroutine;
    public TextMeshProUGUI CountdownUI;

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

        OwningBoard.Attacker = instigaterUnit;
        CountdownCoroutine = Countdown();
        StartCoroutine(CountdownCoroutine);
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(CountdownCoroutine);
        OwningBoard.Attacker = null;
        CountdownUI.SetText("3.00");

    }

    private IEnumerator Countdown()
    {
        float time = 3f;

        while (time > 0)
        {
            time -= Time.deltaTime;
            CountdownUI.SetText(time.ToString("F2"));
            yield return null;
        }
        CountdownUI.SetText("3.00");
        OwningBoard.OnEndTurn();
    }
}
