using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitSpawnerScript : MonoBehaviour
{
    public GameObject unit;
    public ManagerScript manager;

    // Start is called before the first frame update
    void Start()
    {
        int units;
        if (Offspring.getRound() == 0){
            units = Constants.numberOfUnits;
        } else {
            units = Offspring.getCurrUnits();
        }
        Debug.Log(units);

        float totalSpeed = 0f;

        for (int i = 0; i < units; i++){
            Vector3 starting = new Vector3(Constants.quadsize + 1, 0, Constants.quadsize + 1);
            GameObject currUnit = Instantiate(unit, starting, transform.rotation);
            float thisSpeed;
            if (Offspring.getRound() == 0){
                thisSpeed = Constants.init_speed;
            } else {
                thisSpeed = Offspring.speeds[i] + getSpeedChange();
            }
            currUnit.GetComponent<UnitScript>().setAttributes(thisSpeed);
            totalSpeed += thisSpeed;
        }

        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();
        manager.updateAvgSpeed(totalSpeed / (float)units);


        Offspring.startOfRound();
    }

    private float getSpeedChange(){
        int speed_evol = UnityEngine.Random.Range(-5, 6);
        if (speed_evol == 0){
            return 0f;
        }
        float speed_change = (speed_evol / Math.Abs(speed_evol)) * 0.05f + speed_evol * 0.01f;
        return speed_change;
    }
}
