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
        GameObject config = Instantiate(Resources.Load<GameObject>("Prefabs/TransitionManager"));
        //Self = config.GetComponent<Config>();
        DontDestroyOnLoad(config);
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
