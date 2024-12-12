using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    // Call this method to play the death animation
    public void PlayDeathAnimation()
    {
        animator.SetTrigger("PlayDeath");
    }
}