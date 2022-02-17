using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoom : MonoBehaviour
{
    public GameObject bomb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Weapon") || collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);

            if( collision.gameObject.CompareTag( "Player" ) ) {

                collision.gameObject.GetComponent<PlayerController>().Dead();
            }

            Destroy(gameObject);
        }
    }
}
