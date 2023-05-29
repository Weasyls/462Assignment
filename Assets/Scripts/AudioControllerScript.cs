using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour
{
    public AudioSource[] musicSource;
    public static AudioControllerScript instance;
    public AudioControllerScript audio;

    private void Awake()
    {
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
        for(int i = 0; i < musicSource.Length; i++) 
        {
            musicSource[i].Stop();
        }
    }

    public void PlaySound(int musicToPlay)
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Audio");
        foreach (GameObject music in musicObj)
        {
            DontDestroyOnLoad(music);
        }
        musicSource[musicToPlay].Stop();
        musicSource[musicToPlay].Play();
    }

    public void StopSound(int musicToStop)
    {
        musicSource[musicToStop].Stop();
    }
}
