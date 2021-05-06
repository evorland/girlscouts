using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracker : MonoBehaviour
{
    [SerializeField]
    
    //this will just be one - make array if need several types of AR objects indicators/beacons (water, tools, ett)
    private GameObject beaconPrefab;
    private ARTrackedImageManager trackedImageManager;

    [SerializeField]
    private Text imageTrackedText;

    [SerializeField]
    private Text status;

    [SerializeField]
    private Vector3 scaleFactor = new Vector3(0.1f,0.1f,0.1f);

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();


    private void Awake() {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable(){
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable(){
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        foreach(ARTrackedImage trackedImage in eventArgs.added) {
            InstantiateObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.updated) {
               
            if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                UpdateTrackingObject(trackedImage);
            }
            else if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
            {
                DebuggingTextUpdate("limited", trackedImage.referenceImage.name);
                UpdateLimitedGameObject(trackedImage);
            }
            else
            {
                UpdateNoneGameObject(trackedImage);
            }
        }

        foreach(ARTrackedImage trackedImage in eventArgs.removed) {
            DestroyGameObject(trackedImage);
        }
    }

    private void UpdateTrackingObject(ARTrackedImage updatedImage) {
        if (spawnedPrefabs.TryGetValue(updatedImage.referenceImage.name, out GameObject prefab))
        {
            prefab.transform.position = updatedImage.transform.position;
            prefab.transform.rotation = updatedImage.transform.rotation;
            prefab.SetActive(true);
        }
    }

    private void InstantiateObject(ARTrackedImage addedImage){

        DebuggingTextUpdate("in object instantiation", addedImage.referenceImage.name);
        GameObject prefab = Instantiate<GameObject>(beaconPrefab, transform.parent);
        prefab.transform.position = addedImage.transform.position;
        prefab.transform.rotation = addedImage.transform.rotation;
        spawnedPrefabs.Add(addedImage.referenceImage.name, prefab);
    }

    public void UpdateNoneGameObject(ARTrackedImage updateImage)
    {
           DebuggingTextUpdate("limited", updateImage.referenceImage.name);
        for(int i = 0; i < spawnedPrefabs.Count; i++)
        {
            if(spawnedPrefabs.TryGetValue(updateImage.referenceImage.name, out GameObject prefab))
            {
                prefab.SetActive(false);
            }
        }
    }
    void UpdateLimitedGameObject(ARTrackedImage updatedImage)
        {
            for (int i = 0; i < spawnedPrefabs.Count; i++)
            {
                if (spawnedPrefabs.TryGetValue(updatedImage.referenceImage.name, out GameObject prefab))
                {
                    // if(!prefab.GetComponent<ARTrackedImage>().destroyOnRemoval)
                    // {
                    //     prefab.transform.position = updatedImage.transform.position;
                    //     prefab.transform.rotation = updatedImage.transform.rotation;
                    //     prefab.SetActive(true);
                    // }
                    // else
                    //{
                        prefab.SetActive(false);
                    //}           
                }
            }
        }

    void DestroyGameObject(ARTrackedImage removedImage)
    {
        for (int i = 0; i < spawnedPrefabs.Count; i++)
        {
            if (spawnedPrefabs.TryGetValue(removedImage.referenceImage.name, out GameObject prefab))
            {
                spawnedPrefabs.Remove(removedImage.referenceImage.name);
                Destroy(prefab);
            }
        }
    }

    private void DebuggingTextUpdate(string statusMessage, string name) {
        status.text = $"status: {statusMessage} image {name}";
        imageTrackedText.text =  $"{name}";
    }
}
