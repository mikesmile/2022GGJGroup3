using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator itemAnimator;
    public enum ControlType
    {
        controlA,
        controlB,
    }

    public enum Weapon
    {
        none,
        Sword,
        Shield,
    }

    public ControlType playerControlType = ControlType.controlA;
    public float speed;
    public float jumpForce;

    private float moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isFacingRight = true;
    private bool isGround = false;
    private bool isCanMove = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public AudioMgr Jump;
    private Weapon usedWeapon = Weapon.none;


    void Awake()
    {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            //for jump
            if (isCanMove)
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

            #region 拿到盾
            if ( !guardFreeze() && Input.GetKeyDown(KeyCode.N) && usedWeapon == Weapon.Shield)
            {
                itemAnimator.SetBool("guard", true);
                isCanMove = false;
            }
            else if ( itemAnimator.GetBool("guard") && Input.GetKeyUp(KeyCode.N) && usedWeapon == Weapon.Shield)
            {
                itemAnimator.SetBool("guard", false);
                isCanMove = true;
            }
            else if ( !guardFreeze() && Input.GetKeyDown(KeyCode.M) && usedWeapon == Weapon.Shield)
            {
                itemAnimator.SetBool("guardHead", true);
                isCanMove = false;
            }
            else if ( itemAnimator.GetBool("guardHead") && Input.GetKeyUp(KeyCode.M) && usedWeapon == Weapon.Shield)
            {
                itemAnimator.SetBool("guardHead", false);
                isCanMove = true;
            }
            #endregion
            //sword

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

    public bool guardFreeze()
    {
        if (itemAnimator.GetBool("guard") || itemAnimator.GetBool("guardHead"))
            return true;
        else
            return false;

    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isCanMove)
        {
            if (playerControlType == ControlType.controlA)
            {
                moveInput = Input.GetAxis("Horizontal");

            }
            else if (playerControlType == ControlType.controlB)
            {
                moveInput = Input.GetAxis("Horizontal2");
            }

            animator.SetFloat("speed", Mathf.Abs(moveInput));
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (isFacingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (isFacingRight == true && moveInput < 0)
            {
                Flip();
            }
        }
        else if (!isCanMove)
        {
            animator.SetFloat("speed", 0);
            moveInput = 0;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    void Flip()
    {

        isFacingRight = !isFacingRight;

        var scaler = transform.localScale;
        scaler.x *= -1;

        transform.localScale = scaler;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (usedWeapon != Weapon.none) return;

        if (collision.tag.Equals("Sword"))
        {
            Destroy(collision.transform.gameObject);

            usedWeapon = Weapon.Sword;
            itemAnimator.SetBool("getSword", true);
        }
        else if (collision.tag.Equals("Shield"))
        {
            Destroy(collision.transform.gameObject);

            usedWeapon = Weapon.Shield;
            itemAnimator.SetBool("getShield", true);
        }
    }
}
