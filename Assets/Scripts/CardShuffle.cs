using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle()
    {
        //Deck max size
        int replacements = UnityEngine.Random.Range(0, 10);
        //Deck max unique cards
        int A = UnityEngine.Random.Range (0, 2);
        int B = UnityEngine.Random.Range(0, 2);
        int C = UnityEngine.Random.Range(0, 2);
    }
}
