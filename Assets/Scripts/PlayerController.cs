using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum ControlType
    {
        controlA,
        controlB,
    }

    public ControlType playerControlType = ControlType.controlA;
    public float speed;
    public float jumpForce;

    private float moveInput;

    private Rigidbody2D rb;

    private bool isFacingRight = true;

    private bool isGround = false;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Awake()
    {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            extraJumps = extraJumpsValue;
        }

        if (playerControlType == ControlType.controlA)
        {
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
        else if (playerControlType == ControlType.controlB)
        {
            if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGround == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (playerControlType == ControlType.controlA)
        {
            moveInput = Input.GetAxis("Horizontal");

        }
        else if (playerControlType == ControlType.controlB)
        {
            moveInput = Input.GetAxis("Horizontal2");
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if ( isFacingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (isFacingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {

        isFacingRight = !isFacingRight;

        var scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }
}
