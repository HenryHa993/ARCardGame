using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardSide : MonoBehaviour
{
    public Unit BoardUnit;
    public BoardSide OtherBoard;
    public Canvas Arrow;
    public Fade AttackPosition;
    public Fade AttackArrow;
    public GameObject AttackText;

    private void LateUpdate()
    {
        if (BoardUnit == null)
        {
            return;
        }
        
        Vector3 lookPos = OtherBoard.transform.position - BoardUnit.transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler (0, eulerY, 0);
        BoardUnit.transform.rotation = rotation;    }

    public void SetupActionSide()
    {
        Arrow.enabled = true;
        //AttackPosition.SetActive(true);
        
        StartCoroutine(AttackPosition.FadeIn(0.5f));
        StartCoroutine(AttackArrow.FadeIn(0.5f));
        AttackText.SetActive(true);

        //AttackPosition.SetActive(true);
    }
    
    public void SetupDefendSide()
    {
        Arrow.enabled = false;
        //AttackPosition.SetActive(false);
        StartCoroutine(AttackPosition.FadeOut(0.5f));
        StartCoroutine(AttackArrow.FadeOut(0.5f));
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
