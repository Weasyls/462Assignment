using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private CarScript car;
    private const float MinPitchValue = 1.4f;
    public float pitchValue;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        car = CarScript.instance;
    }

    private void Update()
    {
        // Get the value from the other script and use it to control the pitch
        pitchValue = car.GetPitch(); // Assuming GetValue() returns a float
        
        pitchValue = Mathf.Max(pitchValue, MinPitchValue);
        // Set the pitch of the audio source
        audioSource.pitch = pitchValue;
    }
}
