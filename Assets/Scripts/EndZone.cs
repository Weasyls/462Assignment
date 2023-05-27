using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Transform car;
    public Transform point10X;
    public Transform point50X;
    public Transform point200X;
    public Transform point500X;
    public Transform point700X;
    public Transform point1000X;
    public Transform endPos;
    public bool inEndZone = false;
    public static EndZone instance;
    public float multiplier = 1f;
    // Start is called before the first frame update

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
        CheckCarPosition(car);
    }

    public void CheckCarPosition(Transform car)
    {
        if(car.position.z > point10X.position.z && car.position.z < point50X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-25f);
            inEndZone = true;
            multiplier = 10f;
        }
        else if(car.position.z > point50X.position.z && car.position.z < point200X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-50f);
            inEndZone = true;
            multiplier = 50f;
        }
        else if(car.position.z > point200X.position.z && car.position.z < point500X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-75f);
            inEndZone = true;
            multiplier = 200f;
        }
        else if(car.position.z > point500X.position.z && car.position.z < point700X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-100f);
            inEndZone = true;
            multiplier = 500f;
        }
        else if(car.position.z > point700X.position.z && car.position.z < point1000X.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-125f);
            inEndZone = true;
            multiplier = 700f;
        }
        else if(car.position.z > point1000X.position.z && car.position.z < endPos.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-150f);
            inEndZone = true;
            multiplier = 1000f;
        }
        else if(car.position.z > endPos.position.z)
        {
            car.GetComponent<CarScript>().SetSpeedIncrease(-99999f);
            inEndZone = true;
            multiplier = 1000f;
        }
    }

}
