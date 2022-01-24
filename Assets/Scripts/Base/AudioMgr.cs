using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : SingletonBase<AudioMgr> {


    public AudioSource audioSource;
    public AudioSource player1Source;
    public AudioSource player2Source;

    public AudioClip JumpClip;
    public AudioClip Attack;

    public void Jump()
    {
        audioSource.PlayOneShot(JumpClip);
        audioSource.PlayOneShot(Attack);
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump1() {

        player1Source.PlayOneShot( JumpClip );
    }

    public void Jump2() {

        player2Source.PlayOneShot( JumpClip );
    }
}
