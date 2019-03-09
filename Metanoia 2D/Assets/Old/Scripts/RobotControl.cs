using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Transform floorChecker;
    [SerializeField]
    private float speed, jumpForce;
    [SerializeField]
    private LayerMask floorLayer;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform mouthPosition;

    private float greaterGravity = 6, lessGravity = 2;
    private float axisMove;

    private bool flipX = true;
    private bool inFloor;
    private bool isJumping;
    private bool isRunning;

    private float inFloorRadius = 0.2f;

    private float jumpTimeCounter;
    public float JumpTime;
    private bool canJump;

    private void Update()
    {
        GetJump();

        GetMove();

        GetShotCommand();

        SetAnimator();
    }


    // ------------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Aqui vou adicionar o empurrão <<<<<<<<<< - - - - - - -- - -- - - =D 

        public void Push(Vector2 push)
    {
         Rigidbody2D rgd = GetComponent<Rigidbody2D>();
        rgd.AddForce(push+new Vector2(0, 500));
    }







    private void FixedUpdate()
    {
        Move();

        Jump();

        Flip();
    }

    private void GetJump()
    {
        if (inFloor && (Input.GetKeyDown(KeyCode.Space)))
        {
            canJump = true;
            jumpTimeCounter = JumpTime;
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if(canJump && (Input.GetKey(KeyCode.Space) || Input.GetButton("A")))
        {
            if(jumpTimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                canJump = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            canJump = false;
        }
    }

    private void GetMove()
    {
        axisMove = Input.GetAxis("Horizontal");
    }

    private void GetShotCommand()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject newBullet =  Instantiate(bulletPrefab, mouthPosition.position, Quaternion.identity);
            newBullet.GetComponent<ShotControl>().SetDirection(flipX?Vector2.right:Vector2.left);
        }
    }

    private void SetAnimator()
    {
        _animator.SetBool("InFloor", inFloor);
        _animator.SetBool("Run", isRunning);
        _animator.SetBool("Jump", isJumping);
        //_animator.SetBool("Fall", true);
        //_animator.SetFloat("VelocityX", Mathf.Abs(axisMove));
        //_animator.SetFloat("VelocityY", _rigidbody2D.velocity.y);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(axisMove * speed, _rigidbody2D.velocity.y);

        if(axisMove == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }

    private void Jump()
    {
        inFloor = Physics2D.OverlapCircle(floorChecker.position, inFloorRadius, floorLayer);

        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.gravityScale = lessGravity;
            isJumping = false;
        }
        else if (_rigidbody2D.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.gravityScale = greaterGravity;
            isJumping = true;
        }
        else
        {
            _rigidbody2D.gravityScale = 1;
            isJumping = false;
        }
    }

    private void Flip()
    {
        if ((axisMove < 0 && flipX) || (axisMove > 0 && !flipX))
        {
            flipX = !flipX;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(floorChecker.position, inFloorRadius);
    }

    
}
