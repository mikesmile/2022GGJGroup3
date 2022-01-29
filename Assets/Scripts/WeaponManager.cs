using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponManager : SingletonBase<WeaponManager> {


    public PlayerController.Weapon player1UsedWeapon = PlayerController.Weapon.none;

    public PlayerController.Weapon player2UsedWeapon = PlayerController.Weapon.none;

    private Camera cam;

    public float weaponwidth = 1.5f;
    public float PosY = -4f;
    public GameObject sword;
    public GameObject sheild;

    protected override void Awake() {
        base.Awake();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeaponPawn() {

        if( cam == null ) cam = GameObject.Find( "Main Camera" ).GetComponent<Camera>();

        if( player1UsedWeapon == PlayerController.Weapon.none && player2UsedWeapon == PlayerController.Weapon.none )
            RandomWeaponPawn();
        else if( player1UsedWeapon == PlayerController.Weapon.none )
            RandomAnotherWeapon( player2UsedWeapon );
        else if( player2UsedWeapon == PlayerController.Weapon.none )
            RandomAnotherWeapon( player1UsedWeapon );

        //InvokeRepeating( "getCount", 1f, 1f );
    }

    public void ResetWeaponNum() {

        player1UsedWeapon = PlayerController.Weapon.none;
        player2UsedWeapon = PlayerController.Weapon.none;
    }

    public void RandomWeaponPawn() {
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;



        float RandomPos1 = Random.Range( -( halfWidth - weaponwidth ), ( halfWidth - weaponwidth ) );
        float RandomPos2 = Random.Range( -( halfWidth - weaponwidth ), ( halfWidth - weaponwidth ) );

        do {
            RandomPos1 = Random.Range( -halfWidth, halfWidth );
        }
        while( Mathf.Abs( RandomPos1 - RandomPos2 ) < weaponwidth );


        Vector2 newPos1 = new Vector2( RandomPos1, PosY );
        Vector2 newPos2 = new Vector2( RandomPos2, PosY );
        Instantiate( sword, newPos1, Quaternion.identity, transform );
        Instantiate( sheild, newPos2, Quaternion.identity, transform );
    }

    public void RandomAnotherWeapon( PlayerController.Weapon another ) {

        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;
        float RandomPos2 = Random.Range( -( halfWidth - weaponwidth ), ( halfWidth - weaponwidth ) );
        Vector2 newPos2 = new Vector2( RandomPos2, PosY );

        if(another == PlayerController.Weapon.Sword ) {
            Instantiate( sheild, newPos2, Quaternion.identity, transform );
        }
        else if( another == PlayerController.Weapon.Shield ) {
            Instantiate( sword, newPos2, Quaternion.identity, transform );
        }
    }


    public void getCount() {
        //CurWeapon.Clear();
        //for( int i = 0; i < transform.childCount; i++ ) {
        //    CurWeapon.Add( transform.GetChild( i ).gameObject );
        //}
        //if( CurWeapon.Count == 0 ) {
        //    RandomWeaponPawn();
        //}
    }
}
