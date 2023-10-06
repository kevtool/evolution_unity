using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public GameObject EndOfRoundBtn;
    bool preparedToReload;
    public Text currRound;
    public Text currUnits;
    public Text nextUnits;
    public Text currAvgSpeed;
    public Text speedup;

    public void updateNextUnits(){
        nextUnits.text = "Units in Next Round: " + MapTracker.getFoodEaten().ToString();
    }

    public void updateAvgSpeed(float avgSpeed){
        currAvgSpeed.text = "Avg Speed: " + avgSpeed.ToString();
    }

    public void Reload(){
        MapTracker.loadNewRound();
    }

    public void SpeedUp(){
        if (Variables.speedup == 4){
            Variables.speedup = 1;
            speedup.text = "1x";
        } else if (Variables.speedup == 2){
            Variables.speedup = 4;
            speedup.text = "4x";
        } else {
            Variables.speedup = 2;
            speedup.text = "2x";
        }
        Time.timeScale = Constants.timeScale * (float)Variables.speedup;
    }

    // Start is called before the first frame update
    void Start()
    {
        preparedToReload = false;
        currUnits.text = "Units in This Round: " +  MapTracker.getCurrUnits().ToString();
        currRound.text = "Round " + (MapTracker.getRound() + 1).ToString();
        Time.timeScale = Constants.timeScale * (float)Variables.speedup;
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
