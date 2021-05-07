using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Canvas UIManagerCanvas;

    [SerializeField]
    public Text testTxt;

    [SerializeField]
    private GameObject infoPanel;
    private UIManager() { }
    
    public void ShowInfoPanel(string info) {
        InfoPanel ip = infoPanel.GetComponent<InfoPanel>();
        ip.SetInfo(info);
        //string txt = infoPanel.GetComponent<Text>().text;
        infoPanel.SetActive(true);
        testTxt.text = info;
        //infoPanel.GetComponent<Text>().text = info;

    }

    public void HideInfoPanel() {
        infoPanel.SetActive(false);
    }
}
