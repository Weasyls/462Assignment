using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedWriter : MonoBehaviour
{
    public TMP_Text textLabel;

    void Start()
    {
        textLabel.text = CarScript.instance.GetSpeed().ToString() + "\nKm/h";
    }
    
    void Update()
    {
        textLabel.text = CarScript.instance.GetSpeed().ToString() + "\nKm/h";
    }
    
}
