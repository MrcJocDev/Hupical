using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameGod : MonoBehaviour
{

    public TMP_Text coinText;
    public float playerKills;
    public static int playerCoins = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + playerCoins;
    }

    public void increaseDMG()
    {
        if(playerCoins >= 50){
            MeleeAttack.damage += 0.5f;
            playerCoins -= 50;
        }

    }

    public void increaseSPD()
    {
        if(playerCoins >= 120){
            Movement.moveSpeed += 0.3f;
            playerCoins -= 120; 
        }

    }
}