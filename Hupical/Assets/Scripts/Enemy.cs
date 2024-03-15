using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public int coinDrop = 10;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            Destroy(gameObject);
            gameGod.playerCoins += coinDrop;
        }
    }

    public void TakeDamage(float damage){
        health -= damage;
        Debug.Log(health);
    }
}
