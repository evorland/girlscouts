using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabButtons tabButtons;
    public Text label;
    [SerializeField]
    private RawImage img;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabButtons.OnTabEnter(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabButtons.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabButtons.OnTabExit(this);
    }

    public void OnSelected()
    {
        img.CrossFadeAlpha(1, 0, true);
    }

    public void OnUnSelected()
    {
        img.CrossFadeAlpha(0, 0, true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
