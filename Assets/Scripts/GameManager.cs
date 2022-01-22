using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] weapon;
    Camera cam;
    public float weaponwidth = 1.5f;
    public float PosY = -4f;
    //internal static object instance;
    private BossInfo boss;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        RandomWeaponPawn();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossInfo>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        { 
        boss.Hurt(20);
        }
    }

    public void RandomWeaponPawn()  //隨機在地圖上產生武器
    {        
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;
        float LastRamCamPos = 0f;

        for (int i = 0; i < weapon.Length; i++)
        {
            int RandomIndex = Random.Range(0, weapon.Length);
            float RandomPos = Random.Range(-(halfWidth - weaponwidth), (halfWidth - weaponwidth));

            do
            {
                RandomPos = Random.Range(-halfWidth, halfWidth);
            }
            while (Mathf.Abs(RandomPos - LastRamCamPos) < weaponwidth);

            Vector2 newPos = new Vector2(RandomPos, PosY);
            Instantiate(weapon[RandomIndex], newPos, Quaternion.identity);
            //GameObject newWeapon = Instantiate(weapon[RandomIndex], newPos, Quaternion.identity);
            //newWeapon.transform.localScale = new Vector3(Scale, Scale, 1f);
            LastRamCamPos = RandomPos;

        }
    }
}
