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
        if (SceneManager.GetActiveScene().name.Equals("Stage2")) boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossInfo>();
        SwordLest = SwordDB.lesting;
        ShieldLest = ShieldDB.lesting;
        ShieldCollision = GetComponent<EdgeCollider2D>();
        SwordCollision = GetComponent<BoxCollider2D>();
    }

    public void CheckLest()
    {
        Debug.Log(SwordLest);
        if (SwordLest <= 0)
        {
            SwordLest = SwordDB.lesting;
            ShieldLest = ShieldDB.lesting;
            itemAnimator.SetTrigger("ResetToIdle");
        }
        //if (ShieldLest <= 0)
        //{
        //    itemAnimator.SetTrigger("ResetToIdle");
        //}

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
        if (collision.gameObject.CompareTag("Boss") && SwordLest>0)
        {
            Debug.Log("攻擊到囉");
            boss.Hurt(SwordDB.Atk);
            SwordLest -= 1;
        }
        //if (playerController.UsedWeapon == PlayerController.Weapon.Sword && collision.gameObject.CompareTag("Boss") && SwordLest > 0)
        //{
        //    Debug.Log("攻擊到囉");
        //    boss.Hurt(SwordDB.Atk);
        //    SwordLest -= 1;
        //}
    }
}
