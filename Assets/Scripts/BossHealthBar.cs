using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public static int Maxhp;
    public static int Curhp;
    private Image healthbar;
    // Update is called once per frame

    void Start()
    {
        healthbar = GetComponent<Image>();
        Debug.Log("Hi");
        Debug.Log(Curhp);
    }
    void Update()
    {
        healthbar.fillAmount = (float)Curhp / (float)Maxhp;
    }
}
