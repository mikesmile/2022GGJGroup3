using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup popUI;
    public PlayerController player1;
    public PlayerController player2;

    //internal static object instance;
    private void Start()
    {

        WeaponManager.Self.WeaponPawn();

    }

    private void Update()
    {
        if (player1.isLive == false && player2.isLive == false)
        {
            popUI.interactable = true;
            popUI.DOFade(1f, 0.5f).SetEase(Ease.OutQuad).OnComplete(() => {

            });
        }
    }

    public void gameOver()
    {
    }

    public void ToMenu()
    {
        WeaponManager.Self.ResetWeaponNum();
        TransitionManager.Self.LoadScene("Menu");
    }

    public void ToStage1()
    {
        WeaponManager.Self.ResetWeaponNum();
        TransitionManager.Self.LoadScene("Stage1");
    }
}
