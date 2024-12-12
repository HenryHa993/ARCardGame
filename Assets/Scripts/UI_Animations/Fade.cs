using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Color _color;
    
    // Start is called before the first frame update
    void Start()
    {
        _color = GetComponent<Renderer>().material.color;
    }

    public IEnumerator FadeOut(float fromAlpha)
    {
        for (float alpha = fromAlpha; alpha >= 0; alpha -= (Time.deltaTime * 0.5f))
        {
            _color.a = alpha;
            GetComponent<Renderer>().material.SetColor("_BaseColor", _color);
            yield return null;
            //yield return new WaitForSeconds(0.01f);

        }
        Debug.Log("Faded out");
        //enabled = false;
    }
    
    public IEnumerator FadeIn(float toAlpha)
    {
        for (float alpha = 0f; alpha <= toAlpha; alpha += (Time.deltaTime * 0.5f))
        {
            _color.a = alpha;
            GetComponent<Renderer>().material.SetColor("_BaseColor", _color);
            yield return null;
            //yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("Faded in");
    }
}
