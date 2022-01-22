using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllAnimationState : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    private Animator itemAnimator;
    void Awake()
    {
        itemAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestAll()
    {
        playerController.UsedWeapon = PlayerController.Weapon.none;
        playerController.isCanMove = true;

        itemAnimator.SetBool("getSword", false);
        itemAnimator.SetBool("getShield", false);
        itemAnimator.SetBool("attack", false);
        itemAnimator.SetBool("guardHead", false);
        itemAnimator.SetBool("guard", false);
    }
}
