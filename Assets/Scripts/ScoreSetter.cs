using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score = 0;
    public const string HIGH_SCORE = "HighScore";
    
    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString();    
    }

    private void OnDestroy()
    {
        int highscore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        
        if (score > highscore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, Mathf.FloorToInt(score));
        }
    }
}
