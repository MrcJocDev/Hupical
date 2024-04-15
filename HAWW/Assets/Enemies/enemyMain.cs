using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class enemyMain : MonoBehaviour
{

    public float health = 20f;

    public void takeDamage(float dmage){
        health -= dmage;
        if(health <= 0){
            enemyDie();
        }
    }

    void enemyDie(){
        Destroy(gameObject);
    }
}
