using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody rbd;
    [SerializeField] Animator Anim;
    [SerializeField] int jumpSpeed = 200;
    [SerializeField] int ground = 6;
    [SerializeField] int nbSauts ;
    [SerializeField] int nbMaxSAuts;
     public void Jumping()
    {
        //Jump counter
        if(nbSauts >= nbMaxSAuts)
        {
            return;
        }
        //Jump button
            rbd.AddForce(new Vector2(0,jumpSpeed));
            nbSauts++;
    }

    //Called Layer for detect the floor
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == ground)
        {
            nbSauts = 0; 
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        Jumping();
    }
}
