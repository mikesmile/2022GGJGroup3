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
        //Self = config.GetComponent<Config>();
        DontDestroyOnLoad(transition);
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
