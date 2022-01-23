using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInfo : MonoBehaviour
{
    public int BossHp = 100;
    public int blink;
    public float time;
    public SpriteRenderer Goat;
    public SpriteRenderer Lino;
    private Color rcolor;

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
            BossHp = 0;
            Debug.Log("Win");
        }
        BlinkBoss(blink, time, Goat);
    }

    void BlinkBoss(int numblink, float second, SpriteRenderer renderer)
    {
        StartCoroutine(DoBlink(numblink, second, renderer));
    }

    IEnumerator DoBlink(int numblink, float second , SpriteRenderer renderer)
    {
        rcolor = renderer.color;
        for (int i=0; i < numblink * 2; i++ )
        {
            renderer.color = Color.red;
            yield return new WaitForSeconds(second);
        }
        renderer.color = rcolor;
    }
}
