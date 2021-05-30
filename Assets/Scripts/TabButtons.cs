using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButtons : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tabPages;
    [SerializeField]
    private List<string> tabLabels;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private int arrowPadding = 50;

    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private string previousSceneName;

    private List<TabButton> tabButtons;
    private TabButton selectedTab;

    public void Subscribe(TabButton button, bool isSelected = false)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
        if (isSelected)
        {
            OnTabSelected(button);
        }
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
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
        for (int i = 0; i < tabPages.Count; i++)
        {
            tabPages[i].SetActive(i == index);
            if (i == index)
            {
                button.OnSelected();
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (button == selectedTab) { continue; }
            button.OnUnSelected();
        }
    }

    public void NextTab()
    {
        var nextTabIndex = selectedTab.transform.GetSiblingIndex() + 1;
        if (nextTabIndex != tabButtons.Count)
        {
            var nextSelectedTabIndex = tabButtons.FindIndex(button => button.transform.GetSiblingIndex() == nextTabIndex);
            OnTabSelected(tabButtons[nextSelectedTabIndex]);
        }
    }

    public void BackTab()
    {
        var backTabIndex = selectedTab.transform.GetSiblingIndex() - 1;
        if (backTabIndex != -1)
        {
            var backSelectedTabIndex = tabButtons.FindIndex(button => button.transform.GetSiblingIndex() == backTabIndex);
            OnTabSelected(tabButtons[backSelectedTabIndex]);
        }
    }

    // Dynamically creates the proper number of tabs given the number of labels
    private void GenerateButtons()
    {
        var index = 0;
        var containerWidth = GetComponent<RectTransform>().rect.width;
        var numOfButtons = tabLabels.Count;
        var halfOfButtons = Mathf.Floor(numOfButtons / 2);
        var isEvenNumButtons = numOfButtons % 2 == 0;
        var arrowOffset = 0;
        tabLabels.ForEach((label) =>
        {
            // Dynamically creates the UI elements
            GameObject buttonObj = Instantiate(buttonPrefab, transform, false);
            // Keep ordering of buttons
            buttonObj.transform.SetSiblingIndex(index);

            var button = buttonObj.GetComponent<TabButton>();
            var rect = button.GetComponent<RectTransform>();
            var buttonWidth = rect.rect.width;
            rect.SetParent(transform, false);

            // Assumes X starts at local position of 0, center of panel
            var newX = rect.localPosition.x;
            // If there is even number of tabs, use an offset for proper centering
            var evenOffset = isEvenNumButtons ? buttonWidth / 2 : 0;
            // For the first half of buttons, move them left
            // For the second half of buttons, move them right
            // If odd number, position doesn't change
            if (index < halfOfButtons)
            {
                newX -= ((halfOfButtons - index) * buttonWidth) - evenOffset;
            }
            else
            {
                newX += ((index - halfOfButtons) * buttonWidth) + evenOffset;
            }
            // Set the new position
            rect.localPosition = new Vector3(newX, rect.localPosition.y, rect.localPosition.z);

            button.tabButtons = this;
            button.label.text = label;

            var isFirst = index == 0;
            // Track button in list
            Subscribe(button, isFirst);
            if (isFirst)
            {
                arrowOffset = (int)(-newX + buttonWidth / 2);
            }
            index++;
        });
        MoveArrows(arrowOffset);
    }

    // Moves the left/right arrow to their correct position in relation to the tabs
    public void MoveArrows(int offset)
    {
        var offsetWithPadding = offset + arrowPadding;
        var backRect = backButton.GetComponent<RectTransform>();
        backRect.localPosition = new Vector3(backRect.localPosition.x - offsetWithPadding, backRect.localPosition.y, backRect.localPosition.z);
        var nextRect = nextButton.GetComponent<RectTransform>();
        nextRect.localPosition = new Vector3(nextRect.localPosition.x + offsetWithPadding, nextRect.localPosition.y, nextRect.localPosition.z);
    }

    private void Start()
    {
        nextButton.onClick.AddListener(NextTab);
        backButton.onClick.AddListener(BackTab);
        GenerateButtons();
        ResetTabs();
    }
}
