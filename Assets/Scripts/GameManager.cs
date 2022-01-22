using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] weapon;
    Camera cam;
    public float weaponwidth = 1.5f;
    public float PosY = -4f;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        RandomWeaponPawn();
    }

    public void RandomWeaponPawn()  //�H���b�a�ϤW���ͪZ��
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
