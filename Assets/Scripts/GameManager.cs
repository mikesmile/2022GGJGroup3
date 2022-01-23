using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup popUI;
    public GameObject[] weapon;
    public PlayerController player1;
    public PlayerController player2;
    Camera cam;
    public float weaponwidth = 1.5f;
    public float PosY = -4f;
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

        for (int i = 0; i < weapon.Length; i++)
        {
            int RandomIndex = Random.Range(0, weapon.Length);
            float RandomPos = Random.Range(-(halfWidth - weaponwidth), (halfWidth - weaponwidth));

            do
            {
                RandomPos = Random.Range(-halfWidth, halfWidth);
            }
            while (Mathf.Abs(RandomPos - LastRamCamPos) < weaponwidth);

            do
            {
                RandomIndex = Random.Range(0, weapon.Length);
            }
            while (LastRanIndex == RandomIndex);

            Vector2 newPos = new Vector2(RandomPos, PosY);
            Instantiate(weapon[RandomIndex], newPos, Quaternion.identity, transform);

            LastRamCamPos = RandomPos;
            LastRanIndex = RandomIndex;
        }
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
