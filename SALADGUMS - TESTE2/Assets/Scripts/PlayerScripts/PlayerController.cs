using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    //Movement Variables

    public CharacterController controller;
    public Vector3 direction;
    public float speed = 8;

    //Buttons Variables

    public Joystick joystick;
    public Button attackButton;
    public Button jumpButton;

    //Jump Variables

    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    public bool doubleJump = true;

    //Animator Variables

    public Animator animator;
    public Transform model;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        //Check Game Over
        if (PlayerManager.gameOver)
        {
            //Play death animation

            animator.SetTrigger("die");

            //Disable the script

            this.enabled = false;
        }

        //Moviment
           float hInput = joystick.Horizontal;

            direction.x = hInput * speed;

            animator.SetFloat("speed", Mathf.Abs(hInput));

            isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
            animator.SetBool("isGrounded", isGrounded);

            if (isGrounded)
            {
                jumpButton.interactable = true;
            }
            else
            {
                direction.y += gravity * Time.deltaTime; //Add Gravity
                if (doubleJump)
                {
                    JumpTwo();
                }
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball Attack"))
            {
                return;
            }

            //Flip Player
            if (hInput != 0)
            {
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
                model.rotation = newRotation;
            }   

        controller.Move(direction * Time.deltaTime);

        //Reset Z Position
        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (PlayerManager.winLevel)
        {
            animator.SetTrigger("win");
            this.enabled = false;
        }
    }
    public void PlayerAttack()
    {
        //Attack
        if (attackButton)
        {
            animator.SetTrigger("fireBallAttack");
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            if (jumpButton)
            {
                direction.y = jumpForce;
            }
        }
    }

    public void JumpTwo()
    {
        direction.y = jumpForce;
        doubleJump = false;

        if (isGrounded == false)
        {
            animator.SetTrigger("doubleJump");
            jumpButton.interactable = false;
        }
    }
}