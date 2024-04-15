using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gunShoot : MonoBehaviour
{
    // VARIABLES +============+
    // Muzzle flash vars
    public GameObject flash;
    public Transform muzzlePoint;
    // HUD vars
    public TMP_Text clipText;

    // reloading vars
    public float clipSize = 10f;
    bool noAmmo;

    //timer vars
    public float firerate;
    float nextfire;

    // damage and shooting vars
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            clipSize = 10f;
            noAmmo = false;
            damage = 10f;
        }

        if(Input.GetButtonDown("Fire1") && clipSize > 0){
          
            if(Time.time > nextfire){
                nextfire = Time.time + firerate;
                Shoot();
                GameObject test = Object.Instantiate(flash, muzzlePoint.position, muzzlePoint.rotation);
                Destroy(test, 0.05f);
                clipSize -= 1f;

            }

              if(clipSize <= 0f){
                noAmmo = true;
                damage = 0f;
            }
        }

        clipText.text = clipSize + " / inf";
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            enemyMain enemyMain = hit.transform.GetComponent<enemyMain>();
            if(enemyMain != null){
                enemyMain.takeDamage(damage);
            }
        }
    }
}
