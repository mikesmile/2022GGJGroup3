using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BossEasyAI : MonoBehaviour
{
    //[SerializeField]
    //private Volume test;
    public FireBall fireBall;

    public Animator goatAnimator;
    public Animator lionAnimator;

    public Image markR;
    public Image markL;

    private bool isCrazy = false;
    public static bool isLaserAttackStart = false;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(!LaserManager.Self.isLaserOn());
        if(!isLaserAttackStart && BossHealthBar.Curhp <= (float)(BossHealthBar.Maxhp / 2))
        {
            

            lionAnimator.SetBool("attack",true);
            goatAnimator.SetBool("attack", false);

            isLaserAttackStart = true;
            //播放雷射攻擊
            RandomLaser();
        }

        if( BossHealthBar.Curhp > (float)(BossHealthBar.Maxhp / 2) )
        {
            goatAnimator.SetBool("attack", true);

            StartCoroutine("callFireBall");
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
