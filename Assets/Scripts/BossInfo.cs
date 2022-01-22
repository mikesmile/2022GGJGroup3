using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossInfo : MonoBehaviour
{
    public int BossHp = 100;

    void Start()
    {
        HealthBar.Maxhp = BossHp;
        HealthBar.Curhp = BossHp;
    }
    public void Hurt(int Dmg)
    {
        BossHp -= Dmg;
        HealthBar.Curhp = BossHp;
        if (BossHp < 0)
        {
            Debug.Log("Win");
        }
    }
}
