using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardShuffle : MonoBehaviour
{

    private MarkerManager _markerManager;
    public GameObject[] prefabsList;
    private Dictionary<string, GameObject> _prefabsDictionary;
    private Dictionary<string, GameObject> _copy;
    // Start is called before the first frame update
    void Start()
    {
        _markerManager = GetComponent<MarkerManager>();
        _prefabsDictionary = _markerManager._namedPrefabs;
        _copy = _markerManager._namedPrefabs.ToDictionary(entry=>entry.Key, entry=>entry.Value);

        foreach (var I in _copy)
        {
            if (I.Key == "Board")
            {
                continue;
            }

            string key = I.Key;
            //Ramdom Select from prefab list
            GameObject prefab = prefabsList[UnityEngine.Random.Range(0, 4)];
            _prefabsDictionary[key] = prefab;
            Debug.Log(key + " changed to " + prefab.name);
        }

        //_prefabsDictionary = _copy.ToDictionary(entry => entry.Key, entry => entry.Value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle()
    {
/*        //Deck max size
        string replacements = UnityEngine.Random.Range(0, 10);
        //Deck max unique cards
        Rock = UnityEngine.Random.Range (0, 2);
        int B = UnityEngine.Random.Range(0, 2);
        int C = UnityEngine.Random.Range(0, 2);*/
    }

}
