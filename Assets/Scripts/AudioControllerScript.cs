/*
 * AudioControllerScript class manages the audio playback in the game.
 * It provides methods to play and stop different music tracks.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour
{
    public AudioSource[] musicSource; // Array of audio sources for music tracks
    public static AudioControllerScript instance;
    public AudioControllerScript audio;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of AudioControllerScript exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Stop all music sources at the start
        for (int i = 0; i < musicSource.Length; i++)
        {
            musicSource[i].Stop();
        }
    }

    // Play a specific music track by index
    public void PlaySound(int musicToPlay)
    {
        // Find all game objects with the "Audio" tag and mark them as don't destroy on load
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Audio");
        foreach (GameObject music in musicObj)
        {
            DontDestroyOnLoad(music);
        }
        
        // Stop the specified music track before playing it
        musicSource[musicToPlay].Stop();
        musicSource[musicToPlay].Play();
    }

    // Stop a specific music track by index
    public void StopSound(int musicToStop)
    {
        musicSource[musicToStop].Stop();
    }
}