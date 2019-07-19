using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public GameObject deathPart, gameOverUI;

    public Animation cameraa;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void Update()
    {

        if(isGround == true)
        {
            extraJumps = extraJumpsValue;
        }
        Debug.Log("JUMP");
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }


    }

    public void JumpButton()
    {

        Debug.Log("JUMP");
        if (extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (extraJumps == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void DownButton()
    {
        if (isGround != true)
        {
            rb.velocity = Vector2.down * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            var particle = Instantiate(deathPart, transform.position, Quaternion.identity);
            gameOverUI.SetActive(true);
            cameraa.Play();

            var manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            var manager2 = GameObject.Find("SpawnManager").GetComponent<ScoreController>();
            manager.SpeedDown();
            manager2.GameOver();

            Destroy(particle, 5);

            Destroy(gameObject);
        }
    }
}
