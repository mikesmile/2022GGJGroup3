using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( "WaitToMenu" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitToMenu() {

        yield return new WaitForSeconds(5);

        WeaponManager.Self.ResetWeaponNum();
        TransitionManager.Self.LoadScene( "Menu" );

    }
}
