using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Variables

    private string currentState = "IdleState";
    private Transform target;

    public float chaseRange = 5;
    public float attackRange = 2;
    public float speed = 3;

    public int health;
    public int maxHealth; 

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Check Game Over
        if (PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState")
        {
            if (distance < chaseRange)
                currentState = "ChaseState";
        }
        else if (currentState == "ChaseState")
        {
            //Play the run animation
            animator.SetTrigger("chase");
            animator.SetBool("IsAttacking", false);

            if(distance < attackRange)
            {
                currentState = "AttackState";
            }

            //Move towards the player
            if (target.position.x > transform.position.x)
            {
                //Move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                //Move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.identity;
            }
        } else if (currentState == "AttackState")
        {
            animator.SetBool("IsAttacking", true);
            if (distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        currentState = "ChaseState";

        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Play death animation
        animator.SetTrigger("IsDead");

        //Disable the srcipt and the collider
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 3);
        this.enabled = false;
    }
}
