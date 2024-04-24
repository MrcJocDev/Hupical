using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class interactScript : MonoBehaviour
{    
    // ITEM DROP Vars
    public GameObject wheatPrefab;
    public GameObject wheatSpawm;

    // money on harvest vars
    public TMP_Text moneyText;
    public float money = 0f;
    bool isHarvestable;

    public Transform cam;
    bool someBool = true;
    void Update(){
        RaycastHit hit;


        if(Input.GetKeyDown(KeyCode.F)){
            if(someBool && Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 10) && hit.collider.gameObject.CompareTag("PlantBox")){
                plantcrop.timerIsRunningStc = true;
                someBool = false;
            }

            if(plantcrop.isStage4){
                isHarvestable = true;
                if(isHarvestable && Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 10) && hit.collider.gameObject.CompareTag("Plant")){
                    giveMoney();
                    Vector3 itemSpawn = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    Instantiate(wheatPrefab, wheatSpawm.transform.position, Quaternion.identity);
                    someBool = true;
                    Destroy(hit.collider.gameObject);
                    
                }
            }

            if(Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 10)){
                if(hit.collider.gameObject.CompareTag("collectible")){
                    Destroy(hit.collider.gameObject);
                }
            }
        }        
    }

    void giveMoney(){
        money += 10f;
        moneyText.text = "Money: " + money;
    }
}
