using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksChar6 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;
    private PlayerHealthHandler PHH;

    [Header("Main Attack stuff")]

    public Transform ShotSpot;
    public GameObject Bullet;
    public float MainAttackDownTime = 0.2f;
    public float BaseCritChance = 0.1f;
    public float BaseCritDamageMult = 1.4f;

    public float MainUpgrade3AddedCritChance = 0f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade1DamageIncrease = 3f;
    public float MainUpgrade1CritRateIncrease = 0.2f;
    public float MainUpgrade2CritDamageMultIncrease = 0.4f;
    public float MainUpgrade3DamageIncrease = 3f;
    public float MainUpgrade3CritChanceAdded = 0.03f;

    public float AddedCritChanceFromSecond = 0f;

    [Header("Secondary Attack stuff")]
    public Transform SlotSpot;
    public GameObject Slots;
    public float SecondaryAttackDownTime = 1f;

    //[Header("Secondary Attack Upgrade Changes")]

    
  



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrades = GetComponent<UpgradeHandler>();
        AH = GetComponent<AttackHandler>();
        PHH = GetComponent<PlayerHealthHandler>();

    }




    // Update is called once per frame
    void Update()
    {
        




    }




    public override void MainAttack() {


        GameObject bullet = Instantiate(Bullet, ShotSpot.position, ShotSpot.rotation);



        Bullet bullethitbox = bullet.GetComponent<Bullet>();

        float damage = bullethitbox.Damage;
        float critmult = BaseCritDamageMult;
        float critchance = BaseCritChance;

        if (Upgrades.MainUpgrade1)
        {

            damage += MainUpgrade1DamageIncrease;

            critchance += MainUpgrade1CritRateIncrease;


        }

        if (Upgrades.MainUpgrade2)
        {

            critmult += MainUpgrade2CritDamageMultIncrease;

        }


        if (Upgrades.MainUpgrade3) {

            critchance += MainUpgrade3AddedCritChance;



        }

        if (Upgrades.Passive) {


            critchance += (1 - (PHH.Hp / PHH.MaxHp)) / 2;
        
        
        }

        critchance += AddedCritChanceFromSecond;

        Debug.Log(critchance);

        float Crit = Random.Range(0f, 100f);
        Crit /= 100f;

        if (Crit <= critchance) {


            bullethitbox.IsCrit = true;

            damage *= critmult;

        }


        bullethitbox.Damage = damage;

        AddedCritChanceFromSecond = 0f;

        StartCoroutine(DownTimeWaiter(MainAttackDownTime));



    }



    public override void SecondaryAttack()
    {

        GameObject slot = Instantiate(Slots, SlotSpot.position, Slots.transform.rotation);

        slot.transform.parent = SlotSpot;

        SlotsHandler SH = slot.GetComponent<SlotsHandler>();

        int option = 0;

        if (Upgrades.SecondaryUpgrade3)
        {

            option = Random.Range(0, 4);
            option++;

        }

        else {

            option = Random.Range(0, 5);


        }


        SH.StartSpinning(option);

        StartCoroutine(SecondaryWaiter(SecondaryAttackDownTime));

    }



    public IEnumerator DownTimeWaiter(float Time) {

        AH.CanAttack = false;

        yield return new WaitForSeconds(Time);

        AH.CanAttack= true;


    
    }

    public IEnumerator SecondaryWaiter(float Time)
    {

        AH.CanSecondary = false;

        yield return new WaitForSeconds(Time);

        AH.CanSecondary = true;



    }




}
