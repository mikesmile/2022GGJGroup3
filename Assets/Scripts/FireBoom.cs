using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoom : MonoBehaviour
{
    public GameObject bomb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Weapon") || collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if(collision.gameObject.CompareTag("Player"))
            {
                // player = collision.gameObject.GetComponents<PlayerController>();
                //if(player != null)
                //{
                //    player.Dead();
                //}
            }
        }
    }
}
