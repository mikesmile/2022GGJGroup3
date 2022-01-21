using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System;
using DG.Tweening.Core;

public class TransitionManager : SingletonBase<TransitionManager>
{

    public const string UIPath = "Prefabs/";

    public CanvasGroup group;
    private float transitionDuration = 1f; //轉換場景持續時間

    public Action OutFadeDone;//前alpha結束後
    public Action InFadeDone;//後alpha結束後
    public Action changeSceneDone;//切換場景瞬間
    protected override void Awake()
    {
        base.Awake();

        //SceneManager.activeSceneChanged += ChangedActiveScene;
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        //Debug.LogError( group.alpha );
    }


    public void LoadScene(string name)
    {

        OutFade(() => {

            StartCoroutine(LoadYourAsyncScene(name));
        });
    }


    IEnumerator LoadYourAsyncScene(string name)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        if (changeSceneDone != null) changeSceneDone();
        changeSceneDone = null;

        InFade(null);
    }


    public void OutFade(Action onComplete)
    {
        group.DOFade(1f, transitionDuration).SetEase(Ease.OutQuad).OnComplete(() => {

            if (OutFadeDone != null) OutFadeDone();
            if (onComplete != null) onComplete();

            OutFadeDone = null;
        });
    }

    public void InFade(Action onComplete)
    {
        group.DOFade(0f, transitionDuration).SetEase(Ease.InQuad).OnComplete(() => {

            if (InFadeDone != null) InFadeDone();
            if (onComplete != null) onComplete();

            InFadeDone = null;
        });
    }

}