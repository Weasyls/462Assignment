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
    [SerializeField] private TMP_Text lastScoreText;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private int maxLife;
    [SerializeField] private int lifeReGain;

    private const string LIFE = "Life";
    private const string LIFE_REGAIN = "LifeRegain";
    private int life;

    // Start is called before the first frame update
    private void Start()
    {
        OnApplicationFocus(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) return;

        // Cancel any previous invokes
        CancelInvoke();

        // Get and display the high score
        int highscore = PlayerPrefs.GetInt(ScoreSetter.HIGH_SCORE, 0);
        highScoreText.text = "High Score: " + highscore.ToString();

        // Get and display the last score
        int lastscore = PlayerPrefs.GetInt(ScoreSetter.LAST_SCORE, 0);
        lastScoreText.text = "Last Score: " + lastscore.ToString();

        // Get the remaining life count
        life = PlayerPrefs.GetInt(LIFE, maxLife);

        if (life == 0)
        {
            string lifeRegainTime = PlayerPrefs.GetString(LIFE_REGAIN, string.Empty);

            if (lifeRegainTime == string.Empty) return;

            // Check if the life regain time has passed
            DateTime lifeReady = DateTime.Parse(lifeRegainTime);

            if (lifeReady <= DateTime.Now)
            {
                life = maxLife;
                PlayerPrefs.SetInt(LIFE, life);
            }
            else
            {
                // Enable the play button and schedule the life regain time
                playButton.interactable = true;
                Invoke(nameof(LifeReady), (lifeReady - DateTime.Now).Seconds);
            }
        }

        // Display the remaining life count
        lifeText.text = "Play: (" + life.ToString() + ")";
    }

    // Callback function for when the life is ready
    private void LifeReady()
    {
        playButton.interactable = true;
        life = maxLife;
        PlayerPrefs.SetInt(LIFE, life);
        lifeText.text = "Play: (" + life.ToString() + ")";
    }

    // Load scene 1 and decrement the life count
    public void PlayGame()
    {
        if (life < 1) return;

        // Decrement the life count
        life--;
        AudioControllerScript.instance.PlaySound(5);
        PlayerPrefs.SetInt(LIFE, life);

        if (life == 0)
        {
            // Set the life regain time and schedule a notification (for Android)
            DateTime lifeIsReady = DateTime.Now.AddMinutes(lifeReGain);
            PlayerPrefs.SetString(LIFE_REGAIN, lifeIsReady.ToString());

#if UNITY_ANDROID
            androidNotificationController.ScheduleNotification(lifeIsReady);
#endif
        }

        // Load scene 1
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // Reset the high score to 0
    public void ResetScore()
    {
        PlayerPrefs.SetInt(ScoreSetter.HIGH_SCORE, 0);
        highScoreText.text = "High Score: 0";
    }
}
