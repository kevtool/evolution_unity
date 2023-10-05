using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {
    public const int quadsize = 50;
    public const int numberOfUnits = 50;
    public const int numberOfFood = 100;
    public const float init_energy = 3000;
    public const float init_speed = 1f;
}

public static class Offspring {
    static int currNumberOfUnits = Constants.numberOfUnits;
    static int nextNumberOfUnits;
    static int currRound;
    public static List<float> speeds = new List<float>();
    public static List<float> sizes = new List<float>();

    public static void addOffspring(float speed, float size, int children){
        
        if (children <= 0){
            return;
        }

        for (int i = 0; i < children; i++){
            speeds.Add(speed);
            sizes.Add(size);
        }

        nextNumberOfUnits += children;
        // Debug.Log("info: " + speed + " " + size + " " + children + " " + currNumberOfUnits);
    }

    public static void newRound(){
        currNumberOfUnits = nextNumberOfUnits;
        nextNumberOfUnits = 0;
        currRound += 1;
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

    public static void startOfRound(){
        speeds.Clear();
        sizes.Clear();
    }

    public static void reset(){
        currRound = 1;
        speeds.Clear();
        sizes.Clear();
        currNumberOfUnits = 0;
    }
}