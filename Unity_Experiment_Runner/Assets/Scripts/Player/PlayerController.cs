using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); 
       
        rb.velocity = new Vector3(xMove, rb.velocity.y, rb.velocity.z) * speed;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

            rb.AddForce(jump , ForceMode.Impulse);
            isGrounded = false;
        }
        
        
    }

    
    void OnCollisionStay(){
        isGrounded = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death")
            Debug.Log("Death");
    }

}
