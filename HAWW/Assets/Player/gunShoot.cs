using UnityEngine;

public class gunShoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject shootPoint;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        }
    }
}
