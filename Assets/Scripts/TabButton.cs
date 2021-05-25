using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(Text))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    private TabGroup tabGroup;
    [SerializeField]
    private Text label;
    [SerializeField]
    private RawImage img;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
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
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
