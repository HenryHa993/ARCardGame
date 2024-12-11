using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlashEffect : MonoBehaviour
{
    public Material flashMaterial; // Assign your WhiteFlashMaterial here
    private Material[] originalMaterials; // To store the original materials
    private Renderer modelRenderer;

    private void Start()
    {
        // Get the Renderer and store the original materials
        modelRenderer = GetComponent<Renderer>();
        originalMaterials = modelRenderer.materials;
    }

    public void TriggerFlash(float flashDuration)
    {
        StartCoroutine(FlashCoroutine(flashDuration));
    }

    private IEnumerator FlashCoroutine(float duration)
    {
        // Replace all materials with the flash material
        Material[] flashMaterials = new Material[modelRenderer.materials.Length];
        for (int i = 0; i < flashMaterials.Length; i++)
        {
            flashMaterials[i] = flashMaterial;
        }
        modelRenderer.materials = flashMaterials;

        // Wait for the duration of the flash
        yield return new WaitForSeconds(duration);

        // Restore the original materials
        modelRenderer.materials = originalMaterials;
    }
}
