using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] AndroidNotificationsController androidNotificationController;
    [SerializeField] private Button playButton;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private int maxLife;
    [SerializeField] private int lifeReGain;

    private const string LIFE = "Life";
    private const string LIFE_REGAIN = "LifeRegain";
    private int life;


    // start
    private void Start()
    {
        OnApplicationFocus(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus) return;
        CancelInvoke();
        int highscore = PlayerPrefs.GetInt(ScoreSetter.HIGH_SCORE, 0);
        highScoreText.text = "High Score: " + highscore.ToString();

        life = PlayerPrefs.GetInt(LIFE, maxLife);

        if (life == 0){
            string lifeRegainTime = PlayerPrefs.GetString(LIFE_REGAIN, string.Empty);

            if (lifeRegainTime == string.Empty) return;

            DateTime lifeReady = DateTime.Parse(lifeRegainTime);

            if (lifeReady <= DateTime.Now)
            {
                life = maxLife;
                PlayerPrefs.SetInt(LIFE, life);
            }
            else
            {
                playButton.interactable = true;
                Invoke(nameof(LifeReady),(lifeReady - DateTime.Now).Seconds);
            }
        }
        lifeText.text = "Play: (" + life.ToString() + ")";
    }

    private void LifeReady()
    {
        playButton.interactable = true;
        life = maxLife;
        PlayerPrefs.SetInt(LIFE, life);
        lifeText.text = "Play: (" + life.ToString() + ")";
    }

    //load scene 1
    public void PlayGame()
    {
        if (life < 1) return;
        life--;
        PlayerPrefs.SetInt(LIFE, life);
    
        if (life == 0)
        {
            DateTime lifeIsReady = DateTime.Now.AddMinutes(lifeReGain);
            PlayerPrefs.SetString(LIFE_REGAIN, lifeIsReady.ToString());
            #if UNITY_ANDROID
            androidNotificationController.ScheduleNotification(lifeIsReady);    
            #endif
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
