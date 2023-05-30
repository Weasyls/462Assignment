using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Transform car;
    public Transform point5X;
    public Transform point10X;
    public Transform point25X;
    public Transform point50X;
    public Transform point100X;
    public Transform point200X;
    public Transform endPos;
    public bool inEndZone = false;
    public static EndZone instance;
    public float multiplier = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        CheckCarPosition(car);
    }

    // Check the position of the car and apply the appropriate speed increase and multiplier
    public void CheckCarPosition(Transform car)
    {
        if (car.position.z > point5X.position.z && car.position.z < point10X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-25f);
            inEndZone = true;
            multiplier = 5f;
        }
        else if (car.position.z > point10X.position.z && car.position.z < point25X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-50f);
            inEndZone = true;
            multiplier = 10f;
        }
        else if (car.position.z > point25X.position.z && car.position.z < point50X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-75f);
            inEndZone = true;
            multiplier = 25f;
        }
        else if (car.position.z > point50X.position.z && car.position.z < point100X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-100f);
            inEndZone = true;
            multiplier = 50f;
        }
        else if (car.position.z > point100X.position.z && car.position.z < point200X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-125f);
            inEndZone = true;
            multiplier = 100f;
        }
        else if (car.position.z > point200X.position.z && car.position.z < endPos.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-150f);
            inEndZone = true;
            multiplier = 200f;
        }
        else if (car.position.z > endPos.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-99999f);
            inEndZone = true;
            multiplier = 200f;
        }
    }
}
