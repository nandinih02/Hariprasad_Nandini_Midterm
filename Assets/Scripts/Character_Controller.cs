using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private CapsuleCollider2D capsuleCollider;
    [SerializeField] private LayerMask platformLayerMask;
    private Animator animator;

    public float speed= 20f;
    public bool isFacingLeft = false;
    public bool isGrounded = false;
    [SerializeField] public GameObject groundCheck;
    public float jumpVel = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();

        //Character movement left and right
        float x = Input.GetAxis("Horizontal");
        rigidbody.AddForce(new Vector3(x * speed, 0, 0));
        animator.SetFloat("xSpeed", Mathf.Abs(x));

        //Flip Character in desired direction
        if ((x < 0 && isFacingLeft == false) || (x > 0 && isFacingLeft == true))
        {
            isFacingLeft = !isFacingLeft;
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }

        //Character Jump
        if (isGrounded && Input.GetAxis("Jump")>0)
        {
            rigidbody.velocity = Vector2.up * jumpVel;

        }

        //Character Duck
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isDucking", true);
        }
        else
        {
            animator.SetBool("isDucking", false);
        }

    }

    private void IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.1f, platformLayerMask);
        if (colliders.Length > 0)
        {
            
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("HighJump"))
        {
            rigidbody.velocity = Vector2.up * (jumpVel +3f);
        }

        //if (other.CompareTag("Chest") && Input.GetKeyDown(KeyCode.E))
        //{
            
        //}
    }
}
