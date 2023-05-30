using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public TMP_Text textLabel;
    private bool controller = false;
    float countdown = 30f;
    float oldScore;

    void Start()
    {
        oldScore = ScoreSetter.instance.score;
    }
    void Update()
    {
        //begin the level count-down for ONCE
        if (!controller)
        {
            controller = true;
            StartCoroutine(CountdownRoutine()); // Coroutine başlatılıyor
        }
    }

    // Asynchronous operations for the countdown mechanic
    IEnumerator CountdownRoutine()
    {
        // The counter and write to the text
        while (countdown > 0)
        {
            textLabel.text = "Time : " + countdown.ToString();
            yield return new WaitForSeconds(1);
            countdown -= 1f;
            ScoreSetter.instance.score = oldScore + (countdown)* 12.5f;
            
            
        }

        // When the counter is 0, DO SOMETHING
        yield return new WaitForSeconds(1);
    }
}