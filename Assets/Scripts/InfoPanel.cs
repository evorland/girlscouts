using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour  {
	// Use this for initialization

    [SerializeField]
    private Text Info;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Found_Button()
    {
        ///??? dunno yet
    }

    public void SetInfo(string text)
    {
        Info.text = text;
    }

}
