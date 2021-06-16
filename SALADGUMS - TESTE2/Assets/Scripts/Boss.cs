using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Image damageScreen;
    //Idle
    [Header("Idle")]
    [SerializeField] float idleMoveSpeed;
    [SerializeField] Vector2 idleMoveDirection;
    //Attack Jump
    [Header("AttackUpNDown")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;
    //Attack directly the player
    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;
    //Ground Check
    [Header("Ground Verify")]
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool goingUp = true;
    private bool facingLeft = true;
    private Rigidbody2D bossRB;
    //
    [Header("SecondShootAttack")]
    [SerializeField] GameObject prefabShoot;
    Vector3 positionShoot;
    [SerializeField] float minShoot, maxShoot;
    [SerializeField] float timerSpawn, timeStart;
    [SerializeField] int lifeBoss;
    [HideInInspector] public int currentLifeBoss;


    // Start is called before the first frame update
    void Start()
    {
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        bossRB = GetComponent<Rigidbody2D>();
        damageScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Verify AttackUpNDown
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);
        IdleState();
    }

    void IdleState()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        bossRB.velocity = idleMoveSpeed * idleMoveDirection;
    }

    void ChangeDirection()
    {
        goingUp = !goingUp;
        idleMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        idleMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.currentHealth -= 10;
            damageScreen.enabled = true;
        }
    }
}
