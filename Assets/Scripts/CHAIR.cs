using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAIR : MonoBehaviour
{
    private bool isHit = false;
    public static CHAIR instance;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !isHit)
        {
            isHit  = true;
            AudioControllerScript.instance.PlaySound(2);
            Destroy(gameObject, 1f);
        }
        else if(!other.gameObject.CompareTag("Player") && !isHit)
        {
            isHit = true;
            Destroy(gameObject, 1f);
        }
    }
}
