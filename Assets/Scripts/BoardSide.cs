using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSide : MonoBehaviour
{
    public Board MainBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entered " + name);
    }
}
