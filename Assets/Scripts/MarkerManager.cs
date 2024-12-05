using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/*Prefabs and associated names.*/
[Serializable]
public struct NamedPrefab
{
    public string Name;
    public GameObject Prefab;
}

/*Manages multiple markers and their associated prefabs.
 Also manages associations of prefabs.*/
public class MarkerManager : MonoBehaviour
{
    [SerializeField]
    public NamedPrefab[] NamedPrefabs;
    
    // Dictionary for prefabs to spawn
    //Checks for AR marker
    public Dictionary<string, GameObject> _namedPrefabs = new Dictionary<string, GameObject>();
    
    // Dictionary for spawned prefabs 
    // Linked spawned units to AR Marker 
    public Dictionary<string, GameObject> _trackedObjects = new Dictionary<string, GameObject>();
    
    private ARTrackedImageManager _trackedImageManager;
    
    void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (NamedPrefab namedPrefab in NamedPrefabs)
        {
            _namedPrefabs.Add(namedPrefab.Name, namedPrefab.Prefab);
        }
    }

    void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //Create object based on image tracked
        UpdateMarkersAdded(eventArgs.added);
        
        // This is shit, and does not work.
        /*foreach (var trackedImage in eventArgs.updated)
        {
            foreach (var gameObject in ARObjects)
            {
                if(gameObject.name == trackedImage.name)
                {
                    gameObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
                }
            }
        }*/
    }

    /*Added images will look through a dictionary to look up the associated
     prefab. Better than bruteforce traversals.*/
    private void UpdateMarkersAdded(List<ARTrackedImage> addedImages)
    {
        if (!addedImages.Any())
        {
            return;
        }

        // Get prefab, spawn game object and store unique game object into dictionary
        foreach (ARTrackedImage addedImage in addedImages)
        {
            /*If we want to do a shuffle feature, would be more intuitive to manipulate the
             NamedPrefabs dictionary keys.*/
            GameObject prefab = _namedPrefabs[addedImage.referenceImage.name];
            GameObject spawnedGameObject = Instantiate(prefab, addedImage.transform);
            _trackedObjects.Add(addedImage.trackableId.ToString(), spawnedGameObject);
        }
    }

    /*Swap via deconstruction. This could be useful for shuffling cards.*/
    private void Swap(string firstKey, string secondKey)
    {
        (_namedPrefabs[firstKey], _namedPrefabs[secondKey]) = (_namedPrefabs[secondKey], _namedPrefabs[firstKey]);
    }
}