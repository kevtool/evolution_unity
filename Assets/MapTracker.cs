using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class MapTracker {
    static int currNumberOfUnits = Constants.numberOfUnits;
    static int nextNumberOfUnits;
    static int currRound;
    public static List<float> speeds = new List<float>();
    public static List<float> sizes = new List<float>();
    public static List<int> foodTracker = new List<int>();
    static int stoppedUnits = 0;
    static int foodEaten = 0;

    public static void addOffspring(float speed, float size, int children){
        
        if (children <= 0){
            return;
        }

        for (int i = 0; i < children; i++){
            speeds.Add(speed);
            sizes.Add(size);
        }

        nextNumberOfUnits += children;
    }

    

    public static int getRound(){
        return currRound;
    }
    public static int getCurrUnits(){
        return currNumberOfUnits;
    }
    public static int getNextUnits(){
        return nextNumberOfUnits;
    }
    public static int getStoppedUnits(){
        return stoppedUnits;
    }
    public static int getFoodEaten(){
        return foodEaten;
    }

    public static void eatFood(){
        foodEaten += 1;
    }

    public static void addFood(int id){
        foodTracker.Add(id);
    }
    public static bool removeFood(int id){
        return foodTracker.Remove(id);
    }

    // Switches to a new Round scene.
    public static void loadNewRound(){
        currNumberOfUnits = nextNumberOfUnits;
        nextNumberOfUnits = 0;
        currRound += 1;
        stoppedUnits = 0;
        foodEaten = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Starts the simulation of that Round scene.
    public static void startSimulation(){

        /* currently the simulation starts as soon as everything is loaded, 
            so we only have to clear some lists.
        */
        speeds.Clear();
        sizes.Clear();
    }

    public static void Stop(){
        stoppedUnits += 1;
    }

    public static void reset(){
        currRound = 1;
        speeds.Clear();
        sizes.Clear();
        currNumberOfUnits = 0;
    }
}