using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;
    public float JumpForce = 10f;
    private bool isJumping = false;

    private Rigidbody2D rb;

    public Animator animator;

    float horizontalMovement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Code for horizontal movement.
        float horizontalinput = Input.GetAxis("Horizontal");
        horizontalMovement = Input.GetAxis("Horizontal") * MoveSpeed;
        Vector2 moveVector = new Vector2(horizontalinput * MoveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        // player is jumping
        if(Input.GetButtonDown("Jump") && !isJumping){ 
            moveVector.y = JumpForce;
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        rb.velocity = moveVector;

        if(horizontalinput < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(horizontalinput > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
}
 