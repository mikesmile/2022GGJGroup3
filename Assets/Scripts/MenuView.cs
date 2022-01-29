using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    private void Awake() {



    }
    // Start is called before the first frame update
    void Start()
    {
        AudioMgr.Self.GetComponent<AudioSource>().Stop();
        AudioMgr.Self.GetComponent<AudioSource>().Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GoToLoungeScene()
    {

        TransitionManager.Self.LoadScene("Stage1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
