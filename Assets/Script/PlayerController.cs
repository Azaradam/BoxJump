using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space]
    public float jumpForce; //Besar gaya lompat.


    private float moveInput; //Input tombol.
    private Rigidbody2D rb; //Rigidbody player


    private bool isGround; //Bool Check is grounded atau enggak.
    [Space]
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround; //Layermask Ground



    private int extraJumps; //Sisa lompatan
    public int extraJumpsValue; //Banyak lompatan maksimal 


    public GameObject deathPart, gameOverUI;
    public Animation cameraa;
    public AudioSource Jump,slide;


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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpButton();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownButton();
        }

    }

    public void JumpButton()
    {
        if (extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            Jump.Play();
        }
        else if (extraJumps == 0 && isGround == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            Jump.Play();
        }
    }

    public void DownButton()
    {
        if (isGround != true)
        {
            rb.velocity = Vector2.down * jumpForce;
            slide.Play();
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
