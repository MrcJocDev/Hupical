using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public float health = 50f;  
    public TMP_Text hp_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp_text.text = "HP: " + health;
        if (health <= 0){
            Destroy(gameObject);
        }
    }

    public void playerTakeDMG(float playerDMG){
        health -= playerDMG;
    }
}
