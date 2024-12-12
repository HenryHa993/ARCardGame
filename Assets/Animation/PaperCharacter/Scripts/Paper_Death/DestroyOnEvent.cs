using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEvent : MonoBehaviour
{
    // This method will destroy the GameObject
    public void DestroyObject()
    {
        Destroy(gameObject); // Removes the GameObject this script is attached to
    }
}