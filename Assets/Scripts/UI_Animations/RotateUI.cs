using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    public float RotationSpeed = 1.0f;
    private void LateUpdate()
    {
        gameObject.transform.Rotate(0,0,RotationSpeed);
    }
}
