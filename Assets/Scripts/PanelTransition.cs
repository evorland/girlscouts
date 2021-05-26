using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTransition : MonoBehaviour
{
    public GameObject CurrentPanel;

    public void ShowNextPanel(GameObject NextPanel) {
        if(NextPanel != null) {
            NextPanel.SetActive(true);
            CurrentPanel.SetActive(false);
        }
    }

    public void ShowPreviousPanel(GameObject PreviousPanel) {
        if(PreviousPanel != null) {
            PreviousPanel.SetActive(true);
            CurrentPanel.SetActive(false);
        }
    }
}
