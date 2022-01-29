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

    private Coroutine blinkRoutine;
    void Start()
    {
        BossHealthBar.Self.Maxhp = BossHp;
        BossHealthBar.Self.Curhp = BossHp;

    }
    public void Hurt(int Dmg)
    {
        BossHp -= Dmg;
        BossHealthBar.Self.Curhp = BossHp;
        
        if( BossHp <= 0 ) {
            BossHp = 0;
            BossHealthBar.Self.Curhp = BossHp;

            Debug.Log( "Win" );

            TransitionManager.Self.LoadScene( "Ending" );

            return;
        }

        BlinkBoss(blink, time, Goat);
    }

    void BlinkBoss(int numblink, float second, SpriteRenderer renderer ) {

        blinkRoutine = null;
        blinkRoutine = StartCoroutine( DoBlink(numblink, second, renderer));
    }

    IEnumerator DoBlink(int numblink, float second , SpriteRenderer renderer)
    {
        renderer.color = Color.white;
        rcolor = renderer.color;
        for (int i=0; i < numblink * 2; i++ )
        {
            renderer.color = Color.red;
            yield return new WaitForSeconds(second);
            renderer.color = rcolor;
            yield return new WaitForSeconds( second );
        }

    }
}
