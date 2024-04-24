using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class spawning : MonoBehaviour
{   
    // timer vars
    public float spawnRate;
    float nextSpawn;

    // other vars
    int randNumb;
    public GameObject enemyGO;
    public GameObject playerTarget;
    // spawners var
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;


     void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool dnBool = DayNight.isDayStc;
        if(!dnBool){
            randGen();
            spawn();
        }        
    }

    void randGen(){
        randNumb = Random.Range(1, 4);
    }

    void spawn(){
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;

            if(randNumb == 1){
                  Instantiate(enemyGO, spawner1.transform.position, spawner1.transform.rotation);
             }
            if(randNumb == 2){
                  Instantiate(enemyGO, spawner2.transform.position, spawner2.transform.rotation);
              }
            if(randNumb == 3){
                  Instantiate(enemyGO, spawner3.transform.position, spawner3.transform.rotation);
                }
        }
    }
}
