using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObj : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake() {

        audioSource = this.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip audioClip) {

        audioSource.PlayOneShot( audioClip );

        Destroy( gameObject, audioClip.length );
    }
}
