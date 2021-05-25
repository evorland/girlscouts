using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToSwap;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private string previousSceneName;
    private List<TabButton> tabButtons;
    private TabButton selectedTab;

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);

        // Default to select first tab 
        if(button.transform.GetSiblingIndex() == 0)
        {
            OnTabSelected(button);
        }
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {

        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        int index = button.transform.GetSiblingIndex();
        for(int i=0; i < objectsToSwap.Count; i++)
        {
            objectsToSwap[i].SetActive(i == index);
            if(i == index)
            {
                button.OnSelected();
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            button.OnUnSelected();
        }
    }

    public void NextTab()
    {
        var nextTabIndex = selectedTab.transform.GetSiblingIndex() + 1;
        if(nextTabIndex == tabButtons.Count)
        {
            SceneManager.LoadScene(nextSceneName);
        } 
        else
        {
            var nextSelectedTabIndex = tabButtons.FindIndex(button => button.transform.GetSiblingIndex() == nextTabIndex);
            OnTabSelected(tabButtons[nextSelectedTabIndex]);
        }
    }

    public void BackTab()
    {
        var backTabIndex = selectedTab.transform.GetSiblingIndex() - 1;
        if (backTabIndex == -1)
        {
            SceneManager.LoadScene(previousSceneName);
        }
        else
        {
            var backSelectedTabIndex = tabButtons.FindIndex(button => button.transform.GetSiblingIndex() == backTabIndex);
            OnTabSelected(tabButtons[backSelectedTabIndex]);
        }
    }

    private void Start()
    {
        nextButton.onClick.AddListener(NextTab);
        backButton.onClick.AddListener(BackTab);
        //SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
        //SceneManager.LoadScene(previousSceneName, LoadSceneMode.Additive);
    }
}
