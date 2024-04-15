using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class enemyMain : MonoBehaviour
{
    // VARIABLESS +======+
    public GameObject player;
    public NavMeshAgent agent;

    public float giveDmg =  10f;

    public Rigidbody rb;
    public float health = 20f;



    private void Start() {   // START FUNC +=======+
        rb = GetComponent<Rigidbody>();    
    }
    private void Update() {  // UPDATE FUNC +=======+
        gotoPlayer();
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

    void gotoPlayer(){  // GO TO PLAYER FUNC +======+
        agent.SetDestination(player.transform.position);
    }

     void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            playerHealth phealth = other.gameObject.GetComponent<playerHealth>();
            phealth.playerTakeDMG(giveDmg);
        }    
    }
   
}
