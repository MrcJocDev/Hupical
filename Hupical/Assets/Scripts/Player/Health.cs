using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static float health = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }        
    }

    public static void playerTakeDMG(float enemyDMG){
        health -= enemyDMG;
        Debug.Log("Enemy dealt damage! Current health" + health);

    }
}
