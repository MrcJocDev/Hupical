using UnityEngine;

public class enemyMovement : MonoBehaviour
{
   public float enemyMoveSpeed = 3f;
    public Transform playerTransform;
    public bool isChasing; 
    public float chaseDistance;
    void Start()
    {

    }

    void Update()
    {
        if(isChasing){
            if(transform.position.x > playerTransform.position.x){
                transform.localScale = new Vector3(-0.31411f, 0.31411f, 0.31411f);
                transform.position += Vector3.left * enemyMoveSpeed * Time.deltaTime;
            }
            
            if(transform.position.x < playerTransform.position.x){
                transform.localScale = new Vector3(0.31411f, 0.31411f, -0.31411f);
                transform.position += Vector3.right * enemyMoveSpeed * Time.deltaTime;
            }
            
        }

        else{
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance){
                isChasing = true;
            }
        }

    }

}
