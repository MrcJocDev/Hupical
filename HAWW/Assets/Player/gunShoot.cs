using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
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
