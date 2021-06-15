using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlider : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cards;
    
    private RectTransform cardSliderRT;
    private float cardMargin;
    private float cardSpacing;
    private float leftMargin;

    private void InitializeVars()
    {
        cardMargin = 48;
        cardSpacing = 48;
        cardSliderRT = GetComponent<RectTransform>();
        leftMargin = 96;
    }

    private void PositionCards()
    {
        float startingX = leftMargin;
        float startingY = cardSliderRT.localPosition.y;
        for (var i = 0; i < cards.Count; i++)
        {
            float offsetX = startingX + i * (cards[i].rect.size.x + cardSpacing);
            cards[i].transform.position = new Vector3(offsetX, startingY, 0);
        }
    }

    private void SetRTSize(RectTransform rt, Vector2 size)
    {
        Vector2 oldSize = rt.rect.size;
        Vector2 deltaSize = size - oldSize;
    
        rt.offsetMin = rt.offsetMin - new Vector2(
            deltaSize.x * rt.pivot.x,
            deltaSize.y * rt.pivot.y);
        rt.offsetMax = rt.offsetMax + new Vector2(
            deltaSize.x * (1f - rt.pivot.x),
            deltaSize.y * (1f - rt.pivot.y));
    }
    
    private void SetRTWidth(RectTransform rt, float size)
    {
        SetRTSize(rt, new Vector2(size, rt.rect.size.y));
    }
    
    private void SetRTHeight(RectTransform rt, float size)
    {
        SetRTSize(rt, new Vector2(rt.rect.size.x, size));
    }

    private void SetWidthToFitChildren()
    {
        RectTransform cardSliderRT = GetComponent<RectTransform>();

        if (cards.Count > 0)
        {
            float cardWidth = cards[0].rect.size.x + cardSpacing;
            float cardSliderWidth = 2 * cardMargin + (cards.Count) * (cardWidth);

            SetRTWidth(cardSliderRT, cardSliderWidth);
        } 
        else 
        {
            SetRTWidth(cardSliderRT, 0);
        }
    }

    void Start()
    {
        InitializeVars();
        SetWidthToFitChildren();
        PositionCards();
    }

    void Update()
    {

    }
}
