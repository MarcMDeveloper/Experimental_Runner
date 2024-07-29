using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3000.0f;
    public Vector3 jump;
    public float jumpForce = 11.0f;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 8.0f, 0.0f);
        speed = 3000.0f;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector3(xMove * speed * Time.deltaTime, rb.velocity.y, 0);
        }




        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

            rb.AddForce(jump , ForceMode.VelocityChange);
            isGrounded = false;
        }     
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death")
            Debug.Log("Death");
        if(collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

}
