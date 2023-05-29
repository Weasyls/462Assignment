using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingObstacleScript : MonoBehaviour
{
    public int decrease = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CarScript.instance.SlowDown(decrease);
            AudioControllerScript.instance.PlaySound(2);
            Destroy(gameObject);
        }
    }
}
