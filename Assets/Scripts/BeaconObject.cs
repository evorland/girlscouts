using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeaconObject : MonoBehaviour
{
    [SerializeField]
    private GameObject InfoPanel;

    [SerializeField]
    private bool _isFound;

    public bool isFound 
    { 
        get 
        {
            return this._isFound;
        }
        set 
        {
            _isFound = value;
        }
    }

    private string _info;

    public string info {
        get 
        {
            return this._info;
        }
        set 
        {
            _info = value;
        }
    }


 

    // public void OpenInfo(){
    //     if(InfoPanel != null) {   
    //         //grab text on info panel - if exists add object info  
    //         if(InfoPanel.GetComponent<Text>()) {
    //             InfoPanel.GetComponent<Text>().text = info; 
    //         }   
    //         InfoPanel.SetActive(true);
    //     }
    // }

    // public void CloseInfo(){
    //   InfoPanel.SetActive(false);
    // }

    // public void SetOverlayText(string text)
    // {
    //     if(OverlayText != null)
    //     {
    //         OverlayText.gameObject.SetActive(true);
    //         OverlayText.text = text;
    //     }
    // }

    void Awake ()
    {
    }
}