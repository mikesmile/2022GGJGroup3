using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : MonoBehaviour
{
    public int BossHp = 100;

    void Start()
    {
        BossHealthBar.Maxhp = BossHp;
        BossHealthBar.Curhp = BossHp;
    }
    public void Hurt(int Dmg)
    {
        BossHp -= Dmg;
        BossHealthBar.Curhp = BossHp;
        if (BossHp <= 0)
        {
            Debug.Log("Win");
        }
    }
}
