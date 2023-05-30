using UnityEngine;

public class SceneStartSound : MonoBehaviour
{
    public AudioClip startSound; // Sahne başında çalınacak ses dosyası

    private void Start()
    {
        PlayStartSound();
    }

    private void PlayStartSound()
    {
        if (startSound != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = startSound;
            audioSource.loop = true; // Sesin loop'lu olarak çalmasını sağlar
            audioSource.volume = 1f; // Ses seviyesini tam olarak ayarlar
            audioSource.Play();
        }
    }
}