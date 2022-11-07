using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;
    private Animator anim;

    public float gravity;
    private Vector3 velocity;

    //on ground collision check
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGround;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //check on ground
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if (isGround && velocity.y < 0){velocity.y = -1.0f;}
        //get movement input
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;
        dir = transform.forward * verticalMove + transform.right * horizontalMove;
            //animation
        if (dir != Vector3.zero)
        {
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }
            //move
        cc.Move(dir * Time.deltaTime);

        //apply gravity
        velocity.y -= gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        //jump
        if (Input.GetButtonDown("Jump") && isGround) 
        {
            velocity.y = jumpSpeed;
            anim.SetTrigger("jump");
        }

        

        

    }
}
