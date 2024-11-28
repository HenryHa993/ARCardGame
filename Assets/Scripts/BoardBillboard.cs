using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBillboard : MonoBehaviour
{
    private GameObject _board;
    private bool _boardFound;
    
    // Start is called before the first frame update
    void Start()
    {
        _board = GameObject.FindGameObjectWithTag("Board");
        if (_board == null)
        {
            _boardFound = false;
            return;
        }

        _boardFound = true;
    }

    private void LateUpdate()
    {
        if (!_boardFound)
        {
            return;
        }
        
        Vector3 lookPos = _board.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler (0, eulerY, 0);
        transform.rotation = rotation;
        
        //transform.LookAt(_board.transform);
    }
}
