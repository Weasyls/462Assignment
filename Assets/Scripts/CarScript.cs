/*
 * CarScript class controls the movement and interactions of the car in the game.
 * It handles the car's speed, turning, collision detection, and audio playback.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float speed = 30f; // Initial speed of the car
    [SerializeField] private float speedIncrease = 0.1f; // Rate of speed increase over time
    [SerializeField] private float turnSpeedVal = 50f; // Turning speed of the car
    public static CarScript instance; // Singleton instance of the car script
    public float pitch; // Current pitch value for audio playback

    private float horizontalInput; // Input value for horizontal movement

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetPitch(speed / 30f); // Set the pitch value based on the current speed
        speed += speedIncrease * Time.deltaTime; // Increase the speed over time

        // Check if the car has reached the end zone
        if (speed <= 0 && EndZone.instance.inEndZone)
        {
            SetSpeedIncrease(0); // Stop the speed increase
            speed = 0; // Set the speed to 0
            AudioControllerScript.instance.PlaySound(0); // Play a sound effect
            ScoreSetter.instance.CalculateScore(EndZone.instance.multiplier); // Calculate the score
            SceneLoader.instance.LoadNextScene(); // Load the next level or main menu
        }
        // Check if the car has stopped outside the end zone
        else if (speed <= 0 && !EndZone.instance.inEndZone)
        {
            SetSpeedIncrease(0); // Stop the speed increase
            speed = 0; // Set the speed to 0
            AudioControllerScript.instance.PlaySound(1); // Play a sound effect
            SceneManager.LoadScene(0); // Load the main menu
        }

        // Rotate the car based on the horizontal input and turn speed
        transform.Rotate(0f, horizontalInput * turnSpeedVal * Time.deltaTime, 0f);

        // Move the car forward based on the current speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Handle collision with other objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            AudioControllerScript.instance.PlaySound(2); // Play a sound effect
            AudioControllerScript.instance.PlaySound(1); // Play a sound effect
            SceneManager.LoadScene(0); // Load the main menu
        }
    }

    // Set the input value for turning the car
    public void Turn(int value)
    {
        if (value != 0)
        {
            AudioControllerScript.instance.PlaySound(6); // Play a sound effect
        }
        horizontalInput = value;
    }

    // Increase the speed of the car by a specified amount
    public void SpeedUp(int speedChange)
    {
        speed += speedChange;
        // AudioControllerScript.instance.PlaySound(4);
    }

    // Increase the speed of the car significantly by a specified amount
    public void SpeedUpImmensely(int speedChange)
    {
        speed *= speedChange;
        // AudioControllerScript.instance.PlaySound(4);
    }

    // Decrease the speed of the car by a specified amount
    public void SlowDown(int speedChange)
    {
        speed -= speedChange;
        AudioControllerScript.instance.PlaySound(3); // Play a sound effect
    }

    // Decrease the speed of the car significantly by a specified amount
    public void SlowDownImmensely(int speedChange)
    {
        speed /= speedChange;
        AudioControllerScript.instance.PlaySound(3); // Play a sound effect
    }

    // Set the speed increase rate of the car
    public void SetSpeedIncrease(float speedIncrease)
    {
        this.speedIncrease = speedIncrease;
    }

    // Get the current pitch value for audio playback
    public float GetPitch()
    {
        return pitch;
    }

    // Set the pitch value for audio playback
    public void SetPitch(float pitch)
    {
        this.pitch = pitch;
    }

    public int GetSpeed()
    {
        return Mathf.FloorToInt(speed);
    }
}
