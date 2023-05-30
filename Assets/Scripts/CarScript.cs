using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float turnSpeedVal = 50f;
    public static CarScript instance;
    public float pitch;

    private float horizontalInput;

    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Update()
    {
        SetPitch(speed/30f);
        speed += speedIncrease * Time.deltaTime;
        if(speed <= 0 && EndZone.instance.inEndZone){
            SetSpeedIncrease(0);
            speed = 0;
            AudioControllerScript.instance.PlaySound(0);
            ScoreSetter.instance.CalculateScore(EndZone.instance.multiplier);
            SceneManager.LoadScene(0);
            //Sonraki levele geçiş ve puan hesabı şeysileri olacak bu arada
        }
        else if(speed <= 0 && !EndZone.instance.inEndZone){
            SetSpeedIncrease(0);
            speed = 0;
            AudioControllerScript.instance.PlaySound(1);
            SceneManager.LoadScene(0);
        }
        transform.Rotate(0f, horizontalInput * turnSpeedVal * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            AudioControllerScript.instance.PlaySound(2);
            AudioControllerScript.instance.PlaySound(1);
            SceneManager.LoadScene(0);
        }
    }

    public void Turn(int value)
    {
        if(value != 0){
            AudioControllerScript.instance.PlaySound(6);
        }
        horizontalInput = value;
    }

    public void SpeedUp(int speedChange)
    {
        speed += speedChange;
        // AudioControllerScript.instance.PlaySound(4);
    }

    public void SpeedUpImmensely(int speedChange)
    {
        speed *= speedChange;
        // AudioControllerScript.instance.PlaySound(4);
    }

    public void SlowDown(int speedChange)
    {
        speed -= speedChange;
        // AudioControllerScript.instance.PlaySound(3);
    }

    public void SlowDownImmensely(int speedChange)
    {
        speed /= speedChange;
        // AudioControllerScript.instance.PlaySound(3);
    }

    public void SetSpeedIncrease(float speedIncrease)
    {
        this.speedIncrease = speedIncrease;
    }

    public float GetPitch()
    {
        return pitch;
    }
    public void SetPitch(float pitch)
    {
        this.pitch = pitch;
    }
}
