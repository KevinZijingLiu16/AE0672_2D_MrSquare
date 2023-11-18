using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;


    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float buildSpeed = 1f;
    public GameObject buildPrefab;
    public Transform buildSpawnPoint;

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    public Transform spotlight;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource buildSound;
    [SerializeField] private AudioSource shootSound;
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Horizontal movement
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalMove, 0);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Flip sprite based on movement direction
        if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true; // Facing left

            spotlight.rotation = Quaternion.Euler(0, 0, 105);
        }
        else if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false; // Facing right
            spotlight.rotation = Quaternion.Euler(0, 0, -105);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 20f;
        }
        else
        {
            moveSpeed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            spotlight.rotation = Quaternion.Euler(0, 0, 0);
           
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            spotlight.rotation = Quaternion.Euler(0, 0, -180);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
         
        }


        // Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            shootSound.Play();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Build();
            buildSound.Play();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
           
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is not grounded
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the bullet spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Set the bullet's direction based on player's facing direction
        if (spriteRenderer.flipX)
        {
            // Facing left
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0f);
        }
        else
        {
            // Facing right
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
        }
    }

    void Build()
    {
        // Instantiate a bullet at the bullet spawn point
        GameObject build = Instantiate(buildPrefab, buildSpawnPoint.position, Quaternion.identity);

        // Set the bullet's direction based on player's facing direction
        if (spriteRenderer.flipX)
        {
            // Facing left
            build.GetComponent<Rigidbody2D>().velocity = new Vector2(-buildSpeed, 0f);
        }
        else
        {
            // Facing right
            build.GetComponent<Rigidbody2D>().velocity = new Vector2(buildSpeed, 0f);
        }
    }
}
