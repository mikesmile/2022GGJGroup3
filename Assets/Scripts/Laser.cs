using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Weapon") )
        {
            playerController = collision.transform.parent.GetComponent<PlayerController>();

            if( playerController.UsedWeapon == PlayerController.Weapon.Shield &&  !playerController.isCanMove ) {

                //把移動的tweener取消，來作縮小的動畫
                LaserManager.Self.StopAllMove();

                this.transform.DOScaleX( 0, 2f ).OnComplete( () => {
                    Debug.LogWarning( "123" );
                    BossEasyAI.Self.isLaserAttackStart = false;
                    LaserManager.Self.StopAllMove();
                    Destroy( this.gameObject );
                } );
            }

        }
        else if( collision.gameObject.CompareTag( "Player" ) ) {

            collision.gameObject.GetComponent<PlayerController>().Dead();//被雷射打死
        }
    }

    private void OnTriggerStay2D( Collider2D collision ) {
       


    }
}
