using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class interactScript : MonoBehaviour
{    

    // money on harvest vars
    public TMP_Text moneyText;
    public float money = 0f;
    bool isHarvestable;

    public Transform cam;
    bool someBool = true;
    void Update(){
        RaycastHit hit;


        if(Input.GetKeyDown(KeyCode.E)){
            if(someBool && Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 10) && hit.collider.gameObject.CompareTag("PlantBox")){
                plantcrop.timerIsRunningStc = true;
                someBool = false;
            }

            if(plantcrop.isStage4){
                isHarvestable = true;
                if(isHarvestable && Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 10) && hit.collider.gameObject.CompareTag("Plant")){
                    giveMoney();
                    Destroy(hit.collider.gameObject);
                    someBool = true;
                    
                }
            }
        }        
    }

    void giveMoney(){
        money += 10f;
        moneyText.text = "Money: " + money;
    }
}
