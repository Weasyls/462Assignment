using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefBfScript : MonoBehaviour
{
    public TextMesh textMesh;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(textMesh.text == "+Spd")
            {
                CarScript.instance.SpeedUp();
            }
            else if(textMesh.text == "-Spd")
            {
                CarScript.instance.SlowDown();
            }
        }
        
    }
}
