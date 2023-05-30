using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedWriter : MonoBehaviour
{
    public TMP_Text textLabel;

    void Start()
    {
        textLabel.text = "Speed : " + CarScript.instance.GetSpeed().ToString();
    }
    
    void Update()
    {
        textLabel.text = "Speed : " + CarScript.instance.GetSpeed().ToString();
    }
    
}
