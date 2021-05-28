using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableCardText : MonoBehaviour
{
    [SerializeField]
    public string label;
    [SerializeField]
    public string value;

    [SerializeField]
    private Text labelComponent;
    [SerializeField]
    private Text valueComponent;

    // Start is called before the first frame update
    void Start()
    {
        labelComponent.text = label;
        valueComponent.text = value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
