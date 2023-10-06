using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    int id;

    public void setID(int num){
        id = num;
    }

    public bool removeFood(){
        return MapTracker.removeFood(id);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){
        if (collider.gameObject.layer == 8){
            MapTracker.eatFood();
        }
    }
}
