using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int Maxhp;
    public static int Curhp;
    private Image healthbar;
    // Update is called once per frame

    private void Start()
    {
        healthbar = GetComponent<Image>();
        //Curhp = Maxhp;
    }
    void Update()
    {
        healthbar.fillAmount = (float)Curhp / (float)Maxhp;
    }
}
