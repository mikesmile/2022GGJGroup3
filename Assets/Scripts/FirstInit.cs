using DG.Tweening;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FirstInit : MonoBehaviour
{
    private GameObject transition;
    private GameObject weaponManager;

    void Awake()
    {
        DOTween.Init();

        if( TransitionManager.Self == null ) {
            transition = Instantiate( Resources.Load<GameObject>( "Prefabs/TransitionCanvas" ) );
            DontDestroyOnLoad( transition );
        }

        if( WeaponManager.Self == null ) {
            weaponManager = Instantiate( Resources.Load<GameObject>( "Prefabs/WeaponManager" ) );
            DontDestroyOnLoad( weaponManager );
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
