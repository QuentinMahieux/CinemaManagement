using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("DontClimb") && !other.CompareTag("Player"))
        {
            PlayerController.instance.isGrounded = true;
            PlayerController.instance.isFly =  false;
        }
        else
        {
            PlayerController.instance.isGrounded = false;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        PlayerController.instance.isGrounded = false;
        PlayerController.instance.isFly = true;
    }
    
}