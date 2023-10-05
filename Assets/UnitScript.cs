using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public float speed;
    float direction;
    float direction_accel;
    int food_eaten;
    float energy;
    public ManagerScript manager;
    bool hasRunStopped;

    public void setAttributes(float currSpeed){
        speed = currSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerScript>();


        int starting_side = Random.Range(0, 4);
        int start_pos = Random.Range(-Constants.quadsize+1, Constants.quadsize);
        if (starting_side == 0){
            transform.position = new Vector3(start_pos, 0, Constants.quadsize);
            direction = 270f;
        } else if (starting_side == 1){
            transform.position = new Vector3(start_pos, 0, -Constants.quadsize);
            direction = 90f;
        } else if (starting_side == 2){
            transform.position = new Vector3(Constants.quadsize, 0, start_pos);
            direction = 180f;
        } else {
            transform.position = new Vector3(-Constants.quadsize, 0, start_pos);
            direction = 0f;
        }

        direction_accel = 0f;
        food_eaten = 0;
        energy = Constants.init_energy;
    }

    // Update is called once per frame
    void Update()
    {
        if (food_eaten < 2 && energy > 0){
            Vector3 dir_vector = new Vector3((float)Mathf.Cos(direction * Mathf.Deg2Rad), 0, (float)Mathf.Sin(direction * Mathf.Deg2Rad));
            transform.position = transform.position + speed * dir_vector * Time.deltaTime;
            energy -= speed * speed;

            if (direction_accel == 0){
                int randnum = Random.Range(0, 7);
                if (randnum == 0){
                    direction_accel += 3f;
                } else if (randnum == 1){
                    direction_accel -= 3f;
                }
            } else {
                direction_accel = 0f;
            }

            direction += direction_accel;
        } else if (hasRunStopped == false) {
            hasRunStopped = true;
            MapTracker.Stop();
            MapTracker.addOffspring(speed, 1f, food_eaten);
        }

        directionAdjust();
        outofBoundsCheck();
    }

    private void directionAdjust(){
        if (direction >= 360){
            direction -= 360f;
        } else if (direction < 0){
            direction += 360f;
        }
    }

    private void outofBoundsCheck(){
        if (transform.position.z > Constants.quadsize && 0 <= direction && direction <= 180){
            direction = 360f - direction;
        } else if (transform.position.z < -Constants.quadsize && 180 <= direction && direction <= 360){
            direction = 360f - direction;
        }

        if (transform.position.x > Constants.quadsize && 0 <= direction && direction <= 90){
            direction += 180f;
        } else if (transform.position.x > Constants.quadsize && 270 <= direction && direction <= 360){
            direction -= 180f;
        }

        if (transform.position.x < -Constants.quadsize && 90 <= direction && direction <= 270){
            direction += 180f;
            if (direction >= 360){
                direction -= 360f;
            }
        }
    }

    private void OnTriggerEnter(Collider collider){
        if (collider.gameObject.layer == 7){
            Destroy(collider.gameObject);
            food_eaten += 1;
            manager.updateNextUnits();
        }
    }
}
