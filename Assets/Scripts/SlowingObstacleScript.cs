using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingObstacleScript : MonoBehaviour
{
    public int decrease = 5; // Amount to decrease the speed of the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            CarScript.instance.SlowDown(decrease); // Call the SlowDown method of the CarScript to decrease the player's speed
            AudioControllerScript.instance.PlaySound(2); // Play sound effect with ID 2
            Destroy(gameObject); // Destroy the slowing obstacle game object
        }
    }
}