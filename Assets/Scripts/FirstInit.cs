using DG.Tweening;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FirstInit : MonoBehaviour
{
    void Awake()
    {
        DOTween.Init();
        GameObject transition = Instantiate(Resources.Load<GameObject>("Prefabs/TransitionCanvas"));
        GameObject weaponManager = Instantiate( Resources.Load<GameObject>( "Prefabs/WeaponManager" ) );
        //Self = config.GetComponent<Config>();
        DontDestroyOnLoad( transition );
        DontDestroyOnLoad( weaponManager );
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
