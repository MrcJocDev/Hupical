using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeWeapon : MonoBehaviour
{
   public bool isPistol;
   public static bool isPistolStc;
   public GameObject pistol;
   public GameObject rifle;

   void Update() {

        isPistolStc = isPistol;   
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Equip2();
            gunShoot.clipSize = 20f;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Equip1();
            gunShoot.clipSize = 10f;
        }
   }

   void Equip1(){
        pistol.gameObject.SetActive(true);
        rifle.gameObject.SetActive(false);
        isPistol = true;
   }

   void Equip2(){
        pistol.gameObject.SetActive(false);
        rifle.gameObject.SetActive(true);
        isPistol = false;
   }
}
