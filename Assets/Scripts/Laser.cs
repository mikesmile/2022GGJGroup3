using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private PlayerController playerController;
    private Tweener tweener;
    private Tweener scaleTweener;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(Tweener tweener)
    {
        this.tweener = tweener;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Weapon"))
        {
            playerController = collision.transform.parent.GetComponent<PlayerController>();

            if( playerController.UsedWeapon == PlayerController.Weapon.Shield &&  !playerController.isCanMove ) {

                //�Ⲿ�ʪ�tweener�����A�ӧ@�Y�p���ʵe

                tweener.Pause();
                scaleTweener = this.transform.DOScaleX(0, 2f).OnComplete(() =>
                {

                    Debug.LogWarning("123");
                    LaserManager.Self.StopAllMove();
                    BossEasyAI.Self.RandomLaser();
                    Destroy(this.gameObject);
                });
            }

        }
        else if( collision.gameObject.CompareTag( "Player" ) ) {


            Debug.LogWarning("死亡");
            collision.gameObject.GetComponent<PlayerController>().Dead();//�Q�p�g����
        }
    }

    private void OnTriggerStay2D( Collider2D collision ) {

        if(playerController != null )
        {
            Debug.LogWarning("有進來嗎");
            Debug.LogWarning(playerController.isCanMove);
            //Debug.LogWarning(collision.gameObject.tag);
            if (playerController.isCanMove)
            {
                Debug.LogError("恢復雷射進行");
                scaleTweener.Kill();
                tweener.Play();

                collision.gameObject.GetComponent<PlayerController>().Dead();
            }

        }

    }
}
