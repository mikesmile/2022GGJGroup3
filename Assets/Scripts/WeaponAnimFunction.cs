using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        itemAnimator=GetComponent<Animator>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossInfo>();
        SwordLest = SwordDB.lesting;
        ShieldLest = ShieldDB.lesting;
        ShieldCollision = GetComponent<EdgeCollider2D>();
        SwordCollision = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(SwordLest <= 0)
        {
            ChangeWeapon();
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
    public void ChangeWeapon()
    {
        itemAnimator.SetTrigger("ResetToIdle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss") && SwordLest>0)
        {
            Debug.Log("2");
            boss.Hurt(SwordDB.Atk);
            SwordLest -= 1;
        }
    }
}
