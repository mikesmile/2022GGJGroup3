using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator itemAnimator;

    [SerializeField]
    private AudioClip jumpClip;
    [SerializeField]
    private AudioClip attackClip;
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
    public bool isLive = true;

    private float moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isFacingRight = true;
    private bool isGround = false;

    [HideInInspector]
    public bool isCanMove = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private Weapon usedWeapon = Weapon.none;

    public Weapon UsedWeapon
    {
        get => usedWeapon;

        set => usedWeapon = value;
    }


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

        //一般操控
        if (playerControlType == ControlType.controlA)
        {

            //for jump
            if (isCanMove)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
                {
                    AudioMgr.Self.PlayAudio( jumpClip );
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGround == true)
                {
                    AudioMgr.Self.PlayAudio( jumpClip );
                    rb.velocity = Vector2.up * jumpForce;
                }
            }

            #region 拿到盾
            if (usedWeapon == Weapon.Shield)
            {
                if (!guardFreeze() && Input.GetKeyDown(KeyCode.Keypad2))
                {
                    itemAnimator.SetBool("guard", true);
                    isCanMove = false;
                }
                else if (itemAnimator.GetBool("guard") && Input.GetKeyUp(KeyCode.Keypad2))
                {
                    itemAnimator.SetBool("guard", false);
                    isCanMove = true;
                }
                else if (!guardFreeze() && Input.GetKeyDown(KeyCode.Keypad3))
                {
                    itemAnimator.SetBool("guardHead", true);
                    isCanMove = false;
                }
                else if (itemAnimator.GetBool("guardHead") && Input.GetKeyUp(KeyCode.Keypad3))
                {
                    itemAnimator.SetBool("guardHead", false);
                    isCanMove = true;
                }
            }
            #endregion



            #region 拿到劍
            if (usedWeapon == Weapon.Sword)
            {
                if (Input.GetKeyDown(KeyCode.Keypad2))
                {
                    itemAnimator.SetBool("attack", true);
                }
                else if (itemAnimator.GetBool("attack") && Input.GetKeyUp(KeyCode.Keypad2))
                {
                    itemAnimator.SetBool("attack", false);
                }
            }
            #endregion

        }
        else if (playerControlType == ControlType.controlB) //第二個操控
        {
            if (isCanMove)
            {
                if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
                {
                    AudioMgr.Self.PlayAudio( jumpClip );

                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                }
                else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGround == true)
                {
                    AudioMgr.Self.PlayAudio( jumpClip );
                    rb.velocity = Vector2.up * jumpForce;
                }
            }

            #region 拿到盾
            if (usedWeapon == Weapon.Shield)
            {
                if (!guardFreeze() && Input.GetKeyDown(KeyCode.V))
                {
                    itemAnimator.SetBool("guard", true);
                    isCanMove = false;
                }
                else if (itemAnimator.GetBool("guard") && Input.GetKeyUp(KeyCode.V))
                {
                    itemAnimator.SetBool("guard", false);
                    isCanMove = true;
                }
                else if (!guardFreeze() && Input.GetKeyDown(KeyCode.B))
                {
                    itemAnimator.SetBool("guardHead", true);
                    isCanMove = false;
                }
                else if (itemAnimator.GetBool("guardHead") && Input.GetKeyUp(KeyCode.B))
                {
                    itemAnimator.SetBool("guardHead", false);
                    isCanMove = true;
                }
            }
            #endregion



            #region 拿到劍
            if (usedWeapon == Weapon.Sword)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    itemAnimator.SetBool("attack", true);
                }
                else if (itemAnimator.GetBool("attack") && Input.GetKeyUp(KeyCode.V))
                {
                    itemAnimator.SetBool("attack", false);
                }
            }
            #endregion
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
        if( collision.transform.name.Contains( "LaserObject" ) ) {

            //if( !isCanMove ) {

            //    //把移動的tweener取消，來作縮小的動畫
            //    LaserManager.Self.StopAllMove();

            //    collision.transform.DOScaleX( 0, 2f ).OnComplete( () => {
            //        Debug.LogWarning( "123" );
            //        BossEasyAI.Self.isLaserAttackStart = false;
            //        LaserManager.Self.StopAllMove();
            //        Destroy( collision.gameObject );
            //    } );
            //}
            //else {
            //    Dead();
            //}
        }


        Debug.Log("拿到的武器是: " + collision.transform.name);
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
    public void Dead()
    {
        this.gameObject.tag = "Untagged";//死亡後不要被火球炸到
        animator.SetTrigger("IsDead");
        itemAnimator.gameObject.SetActive(false);
        rb.velocity = new Vector2(0, rb.velocity.y);
        this.isLive = false;
        this.enabled = false;
    }


}
