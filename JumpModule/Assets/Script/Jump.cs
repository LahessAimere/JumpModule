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
    [SerializeField] bool jumping = true;
    [SerializeField] int ground;
    [SerializeField] bool IsGrounded = true;
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
            IsGrounded = false;
            Anim.SetBool("IdleToJump", true);
            Anim.SetBool("JumpToIdle", false);
        }
        else
        {
            Anim.SetBool("IdleToJump", false);
            Anim.SetBool("JumpToIdle", true);
                
        }
        //Grounded check
        if(IsGrounded)
        {
            jumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == ground)
        {
            IsGrounded = true;
            nbSauts = 0; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
        Debug.Log(Anim);
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
    }

}
