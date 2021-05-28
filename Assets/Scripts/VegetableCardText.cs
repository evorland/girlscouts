using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableCardText : MonoBehaviour
{
    [SerializeField]
    private VegetableCard parent;

    [SerializeField]
    private VegetableTextKeys key;

    [SerializeField]
    private Text labelComponent;
    [SerializeField]
    private Text valueComponent;

    // Start is called before the first frame update
    void Start()
    {
        var textAndLabel = parent.GetLabelAndValue(key);
        labelComponent.text = textAndLabel.label;
        valueComponent.text = textAndLabel.value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
