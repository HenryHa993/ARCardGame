using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinUI : MonoBehaviour
{
    public float SpinSpeed = 1.0f;
    private void LateUpdate()
    {
        gameObject.transform.Rotate(0,SpinSpeed,0);
    }
}
