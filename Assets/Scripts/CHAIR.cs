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
            Destroy(gameObject, 0.5f);
        }
        else if(!other.gameObject.CompareTag("Player") && !isHit)
        {
            isHit = true;
            Destroy(gameObject, 0.5f);
        }
    }
}
