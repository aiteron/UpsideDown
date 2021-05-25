using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public AudioSource Jumping;

    public float speed;
    public float jumpForce;

    public Transform feetPos1;
    public Transform feetPos2;
    public LayerMask whatIsGround;

    public float coyoteTime;
    private float coyoteTimeCounter;

    public ParticleSystem stepParticles;
    private ParticleSystem.EmissionModule footEmission;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.02f;

    private Animator anim;

    private int gems = 0;

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
        if (Time.timeScale == 0)
            return;

        isGrounded = Physics2D.OverlapCircle(feetPos1.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(feetPos2.position, groundCheckRadius, whatIsGround);

        RunUpdate();
        JumpUpdate(isGrounded);

        StepParticlesUpdate(isGrounded); // show footstep effects
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);

        transform.localScale = new Vector2(-1, 1);
        anim.SetBool("IsRunning", true);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        transform.localScale = new Vector2(1, 1);
        anim.SetBool("IsRunning", true);
    }

    public void Jump()
    {
        Jumping.Play();
        rb.velocity = Vector2.up * jumpForce;
        coyoteTimeCounter = 0;
    }

    private void RunUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
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

        if (coyoteTimeCounter > 0 && Input.GetKey(KeyCode.W))
        {
            Jump();
        }

        if (!Input.GetKey(KeyCode.W) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void StepParticlesUpdate(bool isGrounded)
    {
        if (isGrounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            footEmission.rateOverTime = 35f;
        }
        else
        {
            footEmission.rateOverTime = 0f;
        }
    }

    public void AddGem()
    {
        gems++;
    }

    public int GetGemsCount()
    {
        return gems;
    }
}
