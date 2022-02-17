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

        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/LaserObjectR"), rightPoint.transform);

        tweener1 = obj.transform.DOLocalMoveX(-40, 2.5f).OnComplete(()=> {
            Debug.LogWarning("222");
            BossEasyAI.Self.RandomLaser();
            Destroy(obj);
        });

        obj.GetComponent<Laser>().Init(tweener1);

    }

    public void spawnLeftLaser()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/LaserObjectL"), leftPoint.transform);


        tweener2 = obj.transform.DOLocalMoveX(40, 2.5f).OnComplete(() => {
            Debug.LogWarning("222");

            BossEasyAI.Self.RandomLaser();
            Destroy(obj);
        });

        obj.GetComponent<Laser>().Init(tweener2);
    }

    public void StopAllMove()
    {
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
