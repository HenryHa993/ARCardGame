using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera MainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.rotation = MainCamera.transform.rotation;
    }
}
