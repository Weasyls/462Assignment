using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtons : MonoBehaviour
{

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
