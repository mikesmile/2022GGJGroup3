using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening;

public class LaserManager : SingletonBase<LaserManager>
{
    public GameObject rightPoint;
    public GameObject leftPoint;

    public bool isRightStart = true;
    public bool isLeftStart = true;

    private Tweener tweener1;
    private Tweener tweener2;


    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnRightLaser()
    {
        isRightStart = false;

        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/LaserObjectR"), rightPoint.transform);

        tweener1 = obj.transform.DOLocalMoveX(-40, 2.5f).OnComplete(()=> {
            isRightStart = true;
            Debug.LogWarning("222");
            BossEasyAI.isLaserAttackStart = false;
            Destroy(obj);
        });
    }

    public void spawnLeftLaser()
    {
        isLeftStart = false;
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/LaserObjectL"), leftPoint.transform);


        tweener2 = obj.transform.DOLocalMoveX(40, 2.5f).OnComplete(() => {
            isLeftStart = true;
            Debug.LogWarning("222");

            BossEasyAI.isLaserAttackStart = false;
            Destroy(obj);
        });
    }

    public void StopAllMove()
    {
        isRightStart = true;
        isLeftStart = true;
        tweener1.Kill();
        tweener2.Kill();
        tweener1 = null;
        tweener2 = null;
    }

    public bool isLaserOn()
    {
        if (tweener1 != null || tweener2 != null)
            return true;
        else
            return false;


    }
}
