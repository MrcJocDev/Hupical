using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class gunShoot : MonoBehaviour
{
    // VARIABLES +============+

    // Debug vars
    public GameObject debugTrail;
    // Muzzle flash and sound vars
    public GameObject flash;
    public GameObject bloodParticles;
    public AudioSource shotSound;
    public AudioClip test;
    public AudioClip PistolshotClip;
    public AudioClip RifleshotClip;
    public Transform muzzlePoint;

    // HUD vars
    public TMP_Text clipText;

    // reloading vars
    public static float clipSize = 20f;
    public float shotsFired = 0f;
    public float fullClipSize ;
    bool noAmmo;

    //timer vars
    public float firerate;
    float nextfire;

    // damage and shooting vars
    public float pistolDMG = 10f;
    public float rifleDMG = 20f;
    public float range = 100f;
    public Camera fpsCam;

    void Update()
    {           

         if(clipSize <= 0f){
                noAmmo = true;
                rifleDMG = 0f;
                pistolDMG = 0f;
                if(Input.GetKeyDown(KeyCode.R)){
                     if(!changeWeapon.isPistolStc | changeWeapon.isPistolStc){
                         clipSize = 20f;
                         noAmmo = false;
                         rifleDMG = 10f;
                         pistolDMG = 20f;
                        }
                }     
            }
        

        if(Input.GetMouseButton(0) && clipSize > 0){
            if(Time.time > nextfire && changeWeapon.isPistolStc){
                firerate = 0.25f;                                                                           
                nextfire = Time.time + firerate;                                                           
                ShootPistol();                                                                             
                GameObject test = Object.Instantiate(flash, muzzlePoint.position, muzzlePoint.rotation);   
                Destroy(test, 0.05f);                                                                      
                clipSize -= 1f;
                playPistolSFX();
                shotsFired += 1f;
            }

            if(Time.time > nextfire && !changeWeapon.isPistolStc){
                firerate = 0.1f;
                nextfire = Time.time + firerate;
                ShootRifle();
                GameObject test = Object.Instantiate(flash, muzzlePoint.position, muzzlePoint.rotation);
                Destroy(test, 0.05f);
                clipSize -= 1f;
                playRifleSFX();
                shotsFired += 1f;
            }

        }
        clipText.text = clipSize+" / inf";

    }

    void ShootPistol(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red, 100);
            enemyMain enemyMain = hit.transform.GetComponent<enemyMain>();
            if(enemyMain != null){
                GameObject dupedParticles = Instantiate(bloodParticles, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(dupedParticles, 1f);
                enemyMain.takeDamage(pistolDMG);
            }
        }
    }

    void ShootRifle(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red, 100);
            enemyMain enemyMain = hit.transform.GetComponent<enemyMain>();
            if(enemyMain != null){
                GameObject dupedParticles = Instantiate(bloodParticles, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(dupedParticles, 1f);
                enemyMain.takeDamage(rifleDMG);
            }
        }else{
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.blue);
        }
    }

    void playPistolSFX(){
        shotSound.PlayOneShot(PistolshotClip);
    }

    void playRifleSFX(){
        shotSound.PlayOneShot(RifleshotClip);
    }

    void changePistolClip(){
        if(changeWeapon.isPistolStc){
            clipSize = 10f;
        }
    }

    void changeRifleClip(){
        if(!changeWeapon.isPistolStc){
            clipSize = 20f;
        }
    }
}
