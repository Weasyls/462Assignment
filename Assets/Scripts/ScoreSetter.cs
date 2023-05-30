using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public float score = 0;
    public const string HIGH_SCORE = "HighScore";
    public const string LAST_SCORE = "LastScore";
    public static ScoreSetter instance;
    
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
        if(scoreText != null){
            scoreText.text = Mathf.FloorToInt(score).ToString();        
        }
    }

    private void OnDestroy()
    {
        int highscore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        int lastscore = PlayerPrefs.GetInt(LAST_SCORE, 0);
        PlayerPrefs.SetInt(LAST_SCORE, Mathf.FloorToInt(score)); 
        
        if (score > highscore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, Mathf.FloorToInt(score));
        }
    }

    public void CalculateScore(float multiplier)
    {
        score *= multiplier;
    }
}
