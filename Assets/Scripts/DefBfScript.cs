using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DefBfScript : MonoBehaviour
{
    public TMP_Text textMesh;
    public Material redMat;
    public Material greenMat;
    public Renderer left;
    public Renderer right;
    // Start is called before the first frame update
    void Start()
    {;
        if (textMesh.text.StartsWith("+") || textMesh.text.StartsWith("x"))
        {
            left.material = greenMat;
            right.material = greenMat;
        }
        else if (textMesh.text.StartsWith("-") || textMesh.text.StartsWith("÷"))
        {
            left.material = redMat;
            right.material = redMat;
        }
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (textMesh.text.StartsWith("+"))
            {
                // Extract the numeric part of the text (excluding the "+")
                string numericText = textMesh.text.Substring(1);

                // Attempt to parse the numeric part as an integer using int.Parse
                if (int.TryParse(numericText, out int speedIncrease))
                {
                    CarScript.instance.SpeedUp(speedIncrease);
                    // AudioControllerScript.instance.PlaySound(4);
                    Destroy(gameObject);
                }
            }
            else if (textMesh.text.StartsWith("-"))
            {
                // Extract the numeric part of the text (excluding the "-")
                string numericText = textMesh.text.Substring(1);

                // Attempt to parse the numeric part as an integer using int.Parse
                if (int.TryParse(numericText, out int speedDecrease))
                {
                    CarScript.instance.SlowDown(speedDecrease);
                    AudioControllerScript.instance.PlaySound(3);
                    Destroy(gameObject);
                }
            }
            else if(textMesh.text.StartsWith("÷")){
                // Extract the numeric part of the text (excluding the "÷")
                string numericText = textMesh.text.Substring(1);

                // Attempt to parse the numeric part as an integer using int.Parse
                if (int.TryParse(numericText, out int speedDecrease))
                {
                    CarScript.instance.SlowDownImmensely(speedDecrease);
                    AudioControllerScript.instance.PlaySound(3);
                    Destroy(gameObject);
                }
            }
            else if(textMesh.text.StartsWith("x")){
                // Extract the numeric part of the text (excluding the "x")
                string numericText = textMesh.text.Substring(1);

                // Attempt to parse the numeric part as an integer using int.Parse
                if (int.TryParse(numericText, out int speedIncrease))
                {
                    CarScript.instance.SpeedUpImmensely(speedIncrease);
                    // AudioControllerScript.instance.PlaySound(4);
                    Destroy(gameObject);
                }
            }
        }
    }
}
