using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Jump : MonoBehaviour
{
    
    [SerializeField] Rigidbody rbd;
    [SerializeField] Animator Anim;
    [SerializeField] int jumpSpeed = 300;
    [SerializeField] int ground;
    [SerializeField] int nbSauts ;
    [SerializeField] int nbMaxSAuts;
    void Jumping()
    {
        //Jump counter
        if(nbSauts >= nbMaxSAuts)
        {
            return;
        }
        //JUmp button
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            rbd.AddForce(new Vector2(0,jumpSpeed));
            nbSauts++;
            Anim.SetBool("IdleToJump", true);
            Anim.SetBool("JumpToIdle", false);
        }
        else
        {
            Anim.SetBool("IdleToJump", false);
            Anim.SetBool("JumpToIdle", true);
                
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == ground)
        {
            nbSauts = 0; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        Jumping();
    }

}
