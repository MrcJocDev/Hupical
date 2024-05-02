using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnim : MonoBehaviour
{
    public Animator animator;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > 0){
            animator.SetBool("isWalking", true);
        }

        else{
            animator.SetBool("isWalking", false);
        }
    }
}
