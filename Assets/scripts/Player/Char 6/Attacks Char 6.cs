using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksChar6 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;

    [Header("Main Attack stuff")]

    public Transform ShotSpot;
    public GameObject Bullet;
    public float MainAttackDownTime = 0.2f;
    public float BaseCritChance = 0.1f;
    public float BaseCritDamageMult = 1.4f;

    public float MainUpgrade3AddedCritChance = 0f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade1DamageIncrease = 3f;
    public float MainUpgrade1CritDamageMultIncrease = 0.2f;
    public float MainUpgrade2CritDamageMultIncrease = 0.4f;
    public float MainUpgrade3DamageIncrease = 3f;
    public float MainUpgrade3CritChanceAdded = 0.03f;
    

    [Header("Secondary Attack stuff")]
    public Transform SlotSpot;
    public GameObject Slots;
    public List<GameObject> CoinSplosions = new List<GameObject>();
    public GameObject Chips;
    public float SecondaryAttackDownTime = 1f;

    //[Header("Secondary Attack Upgrade Changes")]

    
  



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrades = GetComponent<UpgradeHandler>();
        AH = GetComponent<AttackHandler>();

    }




    // Update is called once per frame
    void Update()
    {
        




    }




    public override void MainAttack() {

       
    }



    public override void SecondaryAttack()
    {

       
    }



    public IEnumerator DownTimeWaiter(float Time) {

        AH.CanAttack = false;

        yield return new WaitForSeconds(Time);

        AH.CanAttack= true;


    
    }






}
