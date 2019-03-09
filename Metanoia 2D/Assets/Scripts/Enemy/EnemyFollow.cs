using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyFollow : MonoBehaviour
{
    public bool Active { get; set; }

    [SerializeField]
    private float speed;
    [SerializeField]
    private float distanceToStart, distanceToStop;
    [SerializeField]
    [Tooltip("Sprite looking for left")]
    private bool LookingForLeft;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private GameObject player;
    private bool followStarted;
    private bool waitForMove;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        player = GameObject.Find("Robot"); //ToDo - Pegar pelo GameManager
    }

    private void Update()
    {
        if (Active)
        {
            if (!followStarted)
            {
                VerifyPositionToStartFollow();
                return;
            }

            VerifyPositionToLook();
        }
    }

    private void FixedUpdate()
    {
        if (Active)
        {
            if (followStarted && !waitForMove)
            {
                if (Vector2.Distance(player.transform.position, transform.position) > distanceToStop)
                {
                    animator.SetBool("Run", true);

                    Vector2 direction = (player.transform.position - transform.position).normalized;
                    direction.y = 0;

                    rigidBody.MovePosition(rigidBody.position + direction * speed * Time.fixedDeltaTime);
                }
                else
                {
                    animator.SetBool("Run", false);
                }
            }
        }
    }

    private void VerifyPositionToStartFollow()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < distanceToStart)
        {
            animator.SetBool("Run", true);
            followStarted = true;
        }
    }

    private void VerifyPositionToLook()
    {
        if (player.transform.position.x < transform.position.x && !LookingForLeft)
        {
            LookingForLeft = true;
            flipX();
        }

        if (player.transform.position.x > transform.position.x && LookingForLeft)
        {
            LookingForLeft = false;
            flipX();
        }
    }

    private void flipX()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public Vector2 GetDirection()
    {
        if (LookingForLeft)
        {
            return Vector2.left;
        }

        return Vector2.right;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanceToStart);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToStop);
    }

   
}
