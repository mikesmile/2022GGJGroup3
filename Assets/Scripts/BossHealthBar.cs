using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : SingletonBase<BossHealthBar>
{
    public int Maxhp;
    public int Curhp;
    private Image healthbar;
    // Update is called once per frame

    protected override void Awake() {

        base.Awake();

        healthbar = GetComponent<Image>();
        Debug.Log( "Hi" );
        Debug.Log( Curhp );
    }


    void Start()
    {

    }
    void Update()
    {
        healthbar.fillAmount = (float)Curhp / (float)Maxhp;
    }
}
