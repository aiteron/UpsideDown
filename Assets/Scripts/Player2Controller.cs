using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private AudioSource Jumping;
    [SerializeField] private AudioSource Death;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] Transform feetPos1;
    [SerializeField] Transform feetPos2;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] float coyoteTime;
    private float coyoteTimeCounter;

    [SerializeField] ParticleSystem stepParticles;
    private ParticleSystem.EmissionModule footEmission;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.02f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        footEmission = stepParticles.emission;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos1.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(feetPos2.position, groundCheckRadius, whatIsGround);

        RunUpdate();
        JumpUpdate(isGrounded);

        StepParticlesUpdate(isGrounded); // show footstep effects
    }

    private void RunUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);

            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            transform.localScale = new Vector2(1, 1);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

            anim.SetBool("IsRunning", false);
        }
    }

    private void JumpUpdate(bool isGrounded)
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0 && Input.GetKey(KeyCode.DownArrow))
        {
            Jumping.Play();
            rb.velocity = Vector2.down * jumpForce;
            coyoteTimeCounter = 0;
        }

        if (!Input.GetKey(KeyCode.DownArrow) && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void StepParticlesUpdate(bool isGrounded)
    {
        if (isGrounded && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            footEmission.rateOverTime = 35f;
        }
        else
        {
            footEmission.rateOverTime = 0f;
        }
    }
}
