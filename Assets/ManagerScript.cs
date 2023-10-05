using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public int stoppedUnits;
    public GameObject EndOfRoundBtn;
    bool preparedToReload;
    public int nextUnitCount;
    public Text currUnits;
    public Text nextUnits;
    public Text currAvgSpeed;

    public void updateNextUnits(){
        nextUnitCount += 1;
        nextUnits.text = nextUnitCount.ToString();
    }

    public void updateAvgSpeed(float avgSpeed){
        currAvgSpeed.text = avgSpeed.ToString();
    }

    public void Stop()
    {
        stoppedUnits += 1;
    }

    public void Reload(){
        Offspring.newRound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        stoppedUnits = 0;
        preparedToReload = false;
        currUnits.text = Offspring.getCurrUnits().ToString();
        Debug.Log(Offspring.getCurrUnits());

        Time.timeScale = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Offspring.getNextUnits());
        if (preparedToReload == true){
            EndOfRoundBtn.SetActive(true);
        } else if (stoppedUnits >= Offspring.getCurrUnits() || Offspring.getNextUnits() >= Constants.numberOfFood){
            preparedToReload = true;
        }
    }
}
