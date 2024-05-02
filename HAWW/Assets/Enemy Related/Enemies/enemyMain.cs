using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class enemyMain : MonoBehaviour
{
    // VARIABLESS +======+

    public GameObject eyes;
    public float detectionRange;
    // ITEM DROP Vars


    //timer vars
    public float roamRate = 5f;
    float nextMove;
    public float firerate;
    float nextfire;

    // enemy stuff. damage and ai 
    public float speed = 5f;
    public GameObject player;
    public NavMeshAgent agent;

    public static float giveDmg =  10f;
    public Rigidbody rb;
    public static float health = 20f;



    private void Start() {   // START FUNC +=======+
        rb = GetComponent<Rigidbody>();    
    }
    private void Update() {  // UPDATE FUNC +=======+
        enemyAi();

    }
    public void takeDamage(float dmage){  // TAKE DAMAGE FUNC +=======+
        health -= dmage;
        if(health <= 0){
            enemyDie();
        }
    }

    void enemyDie(){  // DIE ON 0 HP FUNC +=======+
        Destroy(gameObject);
    }
    
    void OnCollisionEnter(Collision other) {    // DAMAGE PLAYER +======+
        if(other.gameObject.CompareTag("Player")){
            if(Time.time > nextfire){
                nextfire = Time.time + firerate;
                playerHealth phealth = other.gameObject.GetComponent<playerHealth>();
                phealth.playerTakeDMG(giveDmg);
            }
        }   
         
    }

    void enemyAi(){
        if(Vector3.Distance(player.transform.position, transform.position) <= 10){
            agent.SetDestination(player.transform.position);
        }

        else{
            agent.SetDestination(transform.position);
            
    }

    }
}
