using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{

    private void Awake()
    {

        DontDestroyOnLoad( this.gameObject );
        //if (GameMgr.Gamemgr.IsBgmReady)
        //{
        //    //Destroy(this.gameObject);
        //}
        //else
        //{
        //    DontDestroyOnLoad(this.gameObject);
        //    GameMgr.Gamemgr.IsBgmReady = true;
        //}

    }
}
