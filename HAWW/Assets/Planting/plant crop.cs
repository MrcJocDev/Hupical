using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class plantcrop : MonoBehaviour
{
    //timer vars
    public static bool timerIsRunningStc; 
    public float timeRemaining = 0f;

    // stages vars
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;

    // bools 
    bool isPlanted = false;
    bool isStage1;
    bool isStage2;
    bool isStage3;
    public static bool isStage4;

    void Update()
    {
        plantCrop();
        growStage2();
        growStage3();
        growStage4();
        if(plantcrop.timerIsRunningStc){
            timeRemaining += Time.deltaTime;
            isStage1 = true;
            if(timeRemaining >= 3f){
                isStage1 = false;
                isStage2 = true;
            }

            if(timeRemaining >= 6f){
                isStage2 = false;
                isStage3 = true;
            }

            if(timeRemaining >= 9f){
                isStage3 = false;
                plantcrop.isStage4 = true;
            }
        }

        
    }

    void plantCrop(){

        if(isStage1){
            stage1.SetActive(true);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
        }
        
    }
    void growStage2(){
        if(isStage2){
            stage1.SetActive(false);
            stage2.SetActive(true);
            stage3.SetActive(false);
            stage4.SetActive(false);
        }

    } 

    void growStage3(){
        if(isStage3){
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(true);
            stage4.SetActive(false);
        }
        
    } 

    void growStage4(){
        if(plantcrop.isStage4){
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(true);   ;
        }
        
    }   
}  
 