using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToChildFlash : MonoBehaviour
{
    public HitFlashEffect flashEffect; // Reference to the child script

    public void TriggerFlash(float flashDuration)
    {
        if (flashEffect != null)
        {
            flashEffect.TriggerFlash(flashDuration);
        }
    }
}