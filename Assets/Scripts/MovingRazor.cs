using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRazor : MonoBehaviour
{
    public float speed = 5f; //Movement speed of the block 
    public int onHitSpeedDecrease = 5; //Speed decrease when the block hits the player
    private bool movingRight = true; //In the beginning move to the left
    public float rotationSpeed = 60f; // Dönme hızı

    private void Update()
    {
// Rotate the block around its center on the Z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        float movement = speed * Time.deltaTime;

        Vector3 targetPosition;
        if (movingRight)
        {
            targetPosition = transform.position + Vector3.right * movement;
        }
        else
        {
            targetPosition = transform.position + Vector3.left * movement;
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movement);

        // Control the borders
        if (transform.position.x >= 6)
        {
            movingRight = false; // If it's on the right border, change its direction
        }
        else if (transform.position.x <= -6)
        {
            movingRight = true; // If it's on the left border, change its direction
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CarScript.instance.SlowDown(onHitSpeedDecrease);
            AudioControllerScript.instance.PlaySound(2);
            Destroy(gameObject);
        }
    }
}
