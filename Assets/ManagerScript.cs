using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public GameObject EndOfRoundBtn;
    bool preparedToReload;
    int nextUnitCount;
    public Text currRound;
    public Text currUnits;
    public Text nextUnits;
    public Text currAvgSpeed;

    public void updateNextUnits(){
        nextUnitCount += 1;
        nextUnits.text = "Units in Next Round: " + nextUnitCount.ToString();
    }

    public void updateAvgSpeed(float avgSpeed){
        currAvgSpeed.text = "Avg Speed: " + avgSpeed.ToString();
    }

    public void Reload(){
        MapTracker.loadNewRound();
    }

    // Start is called before the first frame update
    void Start()
    {
        preparedToReload = false;
        currUnits.text = "Units in This Round: " +  MapTracker.getCurrUnits().ToString();
        currRound.text = "Round " + (MapTracker.getRound() + 1).ToString();
        Time.timeScale = Constants.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (preparedToReload == true){
            EndOfRoundBtn.SetActive(true);
        } else if (MapTracker.getStoppedUnits() >= MapTracker.getCurrUnits() || MapTracker.getFoodEaten() >= Constants.numberOfFood){
            preparedToReload = true;
        }
    }
}
