using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVFXOnEvent : MonoBehaviour
{
    public ParticleSystem smokeVFX;

    public void PlaySmoke()
    {
        if (smokeVFX != null)
        {
            smokeVFX.Play();
        }
    }
}