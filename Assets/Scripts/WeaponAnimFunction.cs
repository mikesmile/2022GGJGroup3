using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponAnimFunction : MonoBehaviour
{
    [SerializeField]
    WeaponData SwordDB;
    [SerializeField]
    WeaponData ShieldDB;
    int SwordLest;
    int ShieldLest;
    EdgeCollider2D ShieldCollision;
    BoxCollider2D SwordCollision;
    private BossInfo boss;
    private Animator itemAnimator;
    public PlayerController playerController;

    void Start()
    {
        itemAnimator=GetComponent<Animator>();
        if( SceneManager.GetActiveScene().name.Equals( "Stage2" ) )
            boss = GameObject.FindGameObjectWithTag( "Boss" ).GetComponent<BossInfo>();
        
        SwordLest = SwordDB.lesting;
        ShieldLest = ShieldDB.lesting;
        ShieldCollision = GetComponent<EdgeCollider2D>();
        SwordCollision = GetComponent<BoxCollider2D>();
    }

    public void CheckLest()
    {
        //Debug.Log(SwordLest);
        if (SwordLest <= 0)
        {
            Debug.LogWarning("耐久度歸零了 武器不見了");
            SwordLest = SwordDB.lesting;
            itemAnimator.SetTrigger("ResetToIdle");

            //武器壞掉直接紀錄消失
            if( playerController.playerControlType == PlayerController.ControlType.controlA )
                WeaponManager.Self.player1UsedWeapon = PlayerController.Weapon.none;
            else if( playerController.playerControlType == PlayerController.ControlType.controlB )
                WeaponManager.Self.player2UsedWeapon = PlayerController.Weapon.none;

            WeaponManager.Self.hasSword = 0;
            //再次生成武器邏輯
            WeaponManager.Self.WeaponPawn();
        }


    }


    public void OnShieldTick()
    {
        ShieldCollision.enabled = true;

    }
    public void OffShieldTick()
    {
        ShieldCollision.enabled = false;
    }
    public void OnSwordTick()
    {
        SwordCollision.enabled = true;
    }
    public void OffSwordTick()
    {
        SwordCollision.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if( playerController.UsedWeapon == PlayerController.Weapon.Sword && collision.gameObject.CompareTag( "Boss" ) && SwordLest > 0 ) {
            Debug.Log( "攻擊到囉" );
            boss.Hurt( SwordDB.Atk );
            SwordLest -= 1;
        }
        else if( playerController.UsedWeapon == PlayerController.Weapon.Shield && ShieldCollision.enabled && (collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("Fire")) && ShieldLest > 0)
        {
            Debug.Log("防禦到囉");
            ShieldLest -= 1;

            if (ShieldLest <= 0)
            {
                Debug.LogWarning("耐久度歸零了 木盾不見了");

                ShieldLest = ShieldDB.lesting;
                ShieldCollision.enabled = false;
                itemAnimator.SetTrigger("ResetToIdle");

                //木盾壞掉直接紀錄消失
                if (playerController.playerControlType == PlayerController.ControlType.controlA)
                    WeaponManager.Self.player1UsedWeapon = PlayerController.Weapon.none;
                else if (playerController.playerControlType == PlayerController.ControlType.controlB)
                    WeaponManager.Self.player2UsedWeapon = PlayerController.Weapon.none;

                WeaponManager.Self.hasShield = 0;
                //再次生成武器邏輯
                WeaponManager.Self.WeaponPawn();
            }
        }
    }
}
