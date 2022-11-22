using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] Jump JumpModule;

    // Update is called once per frame
    void Update()
    {
      JumpModule.Jumping();
    }
}
