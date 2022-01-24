using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : SingletonBase<AudioMgr> {


    public AudioSource audioSource;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAudio( AudioClip audioClip ) {

        var obj = Instantiate( Resources.Load<GameObject>( "Prefabs/SoundObj" ), this.transform );

        obj.GetComponent<SoundObj>().Play( audioClip );

    }
}
