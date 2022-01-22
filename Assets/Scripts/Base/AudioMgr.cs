using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip JumpClip;
    public AudioClip Attack;

    public void Play()
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
}
