using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnerScript : MonoBehaviour
{
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Constants.numberOfFood; i++){
            int xpos = Random.Range(-Constants.quadsize+5, Constants.quadsize-4);
            int zpos = Random.Range(-Constants.quadsize+5, Constants.quadsize-4);
            Vector3 starting = new Vector3(xpos, 0, zpos);
            Instantiate(food, starting, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
