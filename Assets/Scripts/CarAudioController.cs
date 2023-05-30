/*
 * CarAudioController class manages the audio playback for a car in the game.
 * It adjusts the pitch of the audio source based on the car's current pitch value.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioController : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the audio source component
    private CarScript car; // Reference to the car script
    private const float MinPitchValue = 1f; // Minimum pitch value for the audio source
    public float pitchValue; // Current pitch value for the audio source

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        car = CarScript.instance;
    }

    private void Update()
    {
        // Get the value from the other script and use it to control the pitch
        pitchValue = car.GetPitch(); // Assuming GetPitch() returns a float

        pitchValue = Mathf.Max(pitchValue, MinPitchValue);
        // Set the pitch of the audio source
        audioSource.pitch = pitchValue;
    }
}

