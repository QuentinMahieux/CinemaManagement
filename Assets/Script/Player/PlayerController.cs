using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6;
    
    public Rigidbody rb;
    private Vector3 moveDirection;
    
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        moveDirection = vertical * transform.forward  + horizontal * transform.right;
        
        rb.MovePosition(rb.position + moveDirection * (Time.deltaTime * speed));
    }
}
