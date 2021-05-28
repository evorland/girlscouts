using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableText
{
    public string label;
    public string value;
}

public enum VegetableTextKeys
{
    soilph,
    moisture,
    lightNeeds,
    seasonLength,
    temp,
    cropYield
}

public class VegetableCard : MonoBehaviour
{
    [SerializeField]
    public string title;
    [SerializeField]
    public string soilPH;
    [SerializeField]
    public string soilMoisture;
    [SerializeField]
    public string lightNeeds;
    [SerializeField]
    public string seasonLegnth;
    [SerializeField]
    public string temp;
    [SerializeField]
    public string cropYield;

    public Dictionary<VegetableTextKeys, VegetableText> vegetableTextOptions;

    public VegetableText GetLabelAndValue(VegetableTextKeys key)
    {
        if(vegetableTextOptions == null)
        {
            GenerateOptions();
        }
        return vegetableTextOptions[key];
    }

    private void GenerateOptions()
    {
        vegetableTextOptions = new Dictionary<VegetableTextKeys, VegetableText> 
        {
            { VegetableTextKeys.soilph, new VegetableText{label = "Soil pH:", value = soilPH} },
            { VegetableTextKeys.moisture, new VegetableText{label = "Soil Moisture:", value = soilMoisture} },
            { VegetableTextKeys.lightNeeds, new VegetableText{label = "Light Needs:", value = lightNeeds} },
            { VegetableTextKeys.seasonLength, new VegetableText{label = "Season Length:", value = seasonLegnth} },
            { VegetableTextKeys.temp, new VegetableText{label = "Atomospheric Temp:", value = temp} },
            { VegetableTextKeys.cropYield, new VegetableText{label = "Crop Yield:", value = cropYield} },
        };
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
