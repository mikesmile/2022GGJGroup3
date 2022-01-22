using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : MonoBehaviour
{
    public int BossHp = 100;
    public int blink;
    public float time; 

    void Start()
    {
        BossHealthBar.Maxhp = BossHp;
        BossHealthBar.Curhp = BossHp;
        //Renderer[] renderer = GameObject
    }
    public void Hurt(int Dmg)
    {
        BossHp -= Dmg;
        BossHealthBar.Curhp = BossHp;
        if (BossHp <= 0)
        {
            BossHp = 0;
            Debug.Log("Win");
        }
        //BlinkBoss(blink, time);
    }

    //void BlinkBoss(int numblink, float second)
    //{
    //    StartCoroutine(DoBlink(numblink, second));
    //}

    //IEnumerator DoBlink(int numblink, float second)
    //{
       // for (int i=0; i < numblink * 2; i++ )
        //{
        //    renderer.enabled = !renderer.enabled;
        //    yield return new WaitForSeconds(second);
        //}
        //renderer.enabled = true;
    //}
}
