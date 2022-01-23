using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup popUI;
    public PlayerController player1;
    public PlayerController player2;
    Camera cam;
    public float weaponwidth = 1.5f;
    public float PosY = -4f;
    public GameObject sword;
    public GameObject sheild;
    //internal static object instance;
    public List<GameObject> CurWeapon = new List<GameObject>();
    private void Start()
    {
       
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        RandomWeaponPawn();
        InvokeRepeating("getCount", 1f, 1f);
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

    public void RandomWeaponPawn()  //�H���b�a�ϤW���ͪZ��
    {        
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;
        float LastRamCamPos = 0f;
        int LastRanIndex = 0;


            float RandomPos1 = Random.Range(-(halfWidth - weaponwidth), (halfWidth - weaponwidth));
            float RandomPos2 = Random.Range(-(halfWidth - weaponwidth), (halfWidth - weaponwidth));

        do
            {
                RandomPos1 = Random.Range(-halfWidth, halfWidth);
            }
            while (Mathf.Abs(RandomPos1 - RandomPos2) < weaponwidth);


            Vector2 newPos1 = new Vector2(RandomPos1, PosY);
            Vector2 newPos2 = new Vector2(RandomPos2, PosY);
            Instantiate(sword, newPos1, Quaternion.identity, transform);
            Instantiate(sheild, newPos2, Quaternion.identity, transform);
    }
    public void getCount()
    {
        CurWeapon.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            CurWeapon.Add(transform.GetChild(i).gameObject);
        }
        if (CurWeapon.Count == 0)
        {
            RandomWeaponPawn();
        }
    }
    public void gameOver()
    {
    }

    public void ToMenu()
    {
        TransitionManager.Self.LoadScene("Menu");
    }

    public void ToStage1()
    {
        TransitionManager.Self.LoadScene("Stage1");
    }
}
