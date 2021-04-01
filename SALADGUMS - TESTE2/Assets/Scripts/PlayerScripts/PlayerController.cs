﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Movement Variables

    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;

    //Jump Variables

    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool doubleJump = true;

    //Animator Variables

    public Animator animator;
    public Transform model;

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
        float hInput = Input.GetAxis("Horizontal");

        direction.x = hInput * speed;

        animator.SetFloat("speed", Mathf.Abs(hInput));

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            doubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("fireBallAttack");
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime; //Add Gravity
            if(doubleJump & Input.GetButtonDown("Jump"))
            {
                JumpTwo();
            }
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball Attack"))
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
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        if (PlayerManager.winLevel)
        {
            animator.SetTrigger("win");
            this.enabled = false;
        }
    }

    private void JumpTwo()
    {
        animator.SetTrigger("doubleJump");
        direction.y = jumpForce;
        doubleJump = false;
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
