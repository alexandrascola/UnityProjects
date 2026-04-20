using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple 2D platformer movement script
//Leftand right movement with A and D keys
//Jump when grounded with space key
//Add to the player, assign groundcheck and ground layer in the inspector

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementSimple : MonoBehaviour
{
    //Declare the rigidbody2D
    private Rigidbody2D rb;

    //Movement var
    [Header("Move")]
    public float moveSpeed = 7f;

    //Jump var
    [Header("Jump")]
    public float jumpForce = 12f;

    //Groundcheck var
    [Header("Ground Check")]
    public Transform groundCheck; //tiny empty shape at feet
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer; //set to ground layer in inspector

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        float inputX = Input.GetAxisRaw("Horizontal"); // -1, 0, or 1
        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        //Jumping
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //Draw a small Ground Check Circle in Scene-View
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        
    }
}
