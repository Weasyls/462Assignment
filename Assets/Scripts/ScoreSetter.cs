using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; // Reference to the score text
    public float score = 0; // Current score
    public const string HIGH_SCORE = "HighScore"; // Key for storing the high score in PlayerPrefs
    public const string LAST_SCORE = "LastScore"; // Key for storing the last score in PlayerPrefs
    public static ScoreSetter instance; // Singleton instance of the ScoreSetter class

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the singleton instance to this object
        }
    }

    void Update()
    {
        if(scoreText != null)
        {
            scoreText.text = Mathf.FloorToInt(score).ToString(); // Update the score text with the current score
        }
    }

    private void OnDestroy()
    {
        int highscore = PlayerPrefs.GetInt(HIGH_SCORE, 0); // Get the high score from PlayerPrefs with a default value of 0
        int lastscore = PlayerPrefs.GetInt(LAST_SCORE, 0); // Get the last score from PlayerPrefs with a default value of 0
        PlayerPrefs.SetInt(LAST_SCORE, Mathf.FloorToInt(score)); // Save the current score as the last score in PlayerPrefs

        if (score > highscore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, Mathf.FloorToInt(score)); // If the current score is higher than the high score, update the high score in PlayerPrefs
        }
    }

    public void CalculateScore(float multiplier)
    {
        score *= multiplier; // Multiply the score by the given multiplier
    }
}

