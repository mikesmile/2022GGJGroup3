using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BossEasyAI : SingletonBase<BossEasyAI> {

    //[SerializeField]
    //private Volume test;
    public FireBall fireBall;

    public Animator goatAnimator;
    public Animator lionAnimator;

    public Image markR;
    public Image markL;

    private bool isCrazy = false;
    public bool isLaserAttackStart = false;
    public bool isFireBallStart = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(!LaserManager.Self.isLaserOn());

        //for Test
        //if (!isLaserAttackStart && BossHealthBar.Self.Curhp > (float)(BossHealthBar.Self.Maxhp / 2))
        //{


        //    lionAnimator.SetBool("attack", true);
        //    goatAnimator.SetBool("attack", false);

        //    isLaserAttackStart = true;
        //    //播放雷射攻擊
        //    RandomLaser();
        //}

        //if (BossHealthBar.Self.Curhp <= (float)(BossHealthBar.Self.Maxhp / 2))
        //{
        //    goatAnimator.SetBool("attack", true);

        //    StartCoroutine("callFireBall");
        //}

        //if( !isLaserAttackStart && BossHealthBar.Self.Curhp <= (float)( BossHealthBar.Self.Maxhp / 2 ) ) {


        //    lionAnimator.SetBool( "attack", true );
        //    goatAnimator.SetBool( "attack", false );

        //    isLaserAttackStart = true;
        //    fireBall.isStart = false;
        //    isFireBallStart = false;

        //    //播放雷射攻擊
        //    RandomLaser();
        //}

        //if( !isFireBallStart && BossHealthBar.Self.Curhp > (float)( BossHealthBar.Self.Maxhp / 2 ) ) {
        //    goatAnimator.SetBool( "attack", true );

        //    isFireBallStart = true;

        //    StartCoroutine( "callFireBall" );
        //}

        if( !isFireBallStart ) {
            goatAnimator.SetBool( "attack", true );

            isFireBallStart = true;

            StartCoroutine( "callFireBall" );
        }
    }

    public void RandomLaser()
    {
        int x = Random.Range(0,2);

        if (x == 0)
            StartCoroutine("callRightLaser");
        else if (x == 1)
            StartCoroutine("callLeftLaser");

    }

    IEnumerator callFireBall()
    {
        yield return new WaitForSeconds(5f);

        //播放火球攻擊
        fireBall.isStart = true;

    }

    IEnumerator callRightLaser()
    {
        markR.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        markR.gameObject.SetActive(false);

        if (LaserManager.Self.isRightStart)
            LaserManager.Self.spawnRightLaser();
    }

    IEnumerator callLeftLaser()
    {
        markL.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        markL.gameObject.SetActive(false);

        if (LaserManager.Self.isLeftStart)
            LaserManager.Self.spawnLeftLaser();
    }
}
