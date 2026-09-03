using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttacksChar2 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;
    private PlayerMovement PM;

    [Header("Main Attack stuff")]

    public Transform SpearSpot;
    public Transform SweetSpotSpot;
    public GameObject SpearJab;
    public GameObject SweetSpot;
    public float MainAttackDownTime = 0.3f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade1DamageIncrease = 3f;
    public float MainUpgrade2DamageIncrease = 2f;
    public float MainUpgrade2SweetSpotDamageIncrease = 2f;
    

    [Header("Secondary Attack stuff")]
    
    public float DashSpeed = 3f;
    public float DashTime = 0.5f;
    public int DashesSoFar = 0;
    public float TimeBetweenPuddles = 0.1f;
    public Transform DashHitboxSpot;
    public GameObject DashHitbox;
    public GameObject PoisonPuddle;
    public Transform PoisonPuddleSpot;
    public GameObject DashExplosion;
    public float SecondaryAttackDownTime = 0.5f;


    [Header("Secondary Attack Upgrade Changes")]

    public float SecondaryUpgrade1DamageIncrease = 3f;
    public float SecondaryUpgrade2DamageIncrease = 2f;
    public float SecondaryUpgrade2DashSpeedIncrease = 2f;
    public float SecondaryUpgrade3DamageIncrease = 2f;
    public float SecondaryUpgrade3PuddleDOTIncrease = 2f;
    public float SecondaryUpgrade4ExplosionSizeIncrease = 2f;
    public float SecondaryUpgrade4ExplosionDamageIncrease = 2f;
    
    




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrades = GetComponent<UpgradeHandler>();
        AH = GetComponent<AttackHandler>();
        PM = GetComponent<PlayerMovement>();


    }




    // Update is called once per frame
    void Update()
    {
        




    }




    public override void MainAttack() {

        GameObject spearjab = Instantiate(SpearJab, SpearSpot.position, SpearSpot.rotation);

        spearjab.transform.parent = SpearSpot;

        Hitbox spearjabhit = spearjab.GetComponent<Hitbox>();

        if (Upgrades.MainUpgrade3) {

            spearjabhit.InflictDOT = true;
        
        }

        if (Upgrades.MainUpgrade1) { 
        
            GameObject sweetspot = Instantiate(SweetSpot, SweetSpotSpot.position, SweetSpotSpot.rotation);
            sweetspot.transform.parent = SweetSpotSpot;
            Hitbox sweetspothit = sweetspot.GetComponent<Hitbox>();

            if (Upgrades.MainUpgrade2) {

                SpearSweetSpotMistThing SSSM = sweetspot.GetComponent<SpearSweetSpotMistThing>();
                SSSM.ActivateMist = true;

            }

            if (Upgrades.MainUpgrade3)
            {

                sweetspothit.InflictDOT = true;

            }
        }

        StartCoroutine(DownTimeWaiter(MainAttackDownTime, true));


    }



    public override void SecondaryAttack()
    {

      
        GameObject dashhitbot = Instantiate(DashHitbox, DashHitboxSpot.position, DashHitboxSpot.rotation);

        dashhitbot.transform.parent = DashHitboxSpot;


       

        StartCoroutine(Dashing(dashhitbot));
        

        


    }

    //cannot figure out the double dash thing help asdasdasd
    public IEnumerator Dashing(GameObject dashhitbot) {


        AttackHandler AH = GetComponent<AttackHandler>();

        
        AH.CanAttack = false;

        Hitbox BaseHB = dashhitbot.GetComponent<Hitbox>();

        if (Upgrades.SecondaryUpgrade2) {

            BaseHB.Damage += SecondaryUpgrade2DamageIncrease;
        
        }


        float speed = DashSpeed;
        
        if (Upgrades.SecondaryUpgrade3)
        {

            GameObject firstdashexplosion = Instantiate(DashExplosion, DashHitboxSpot.position, DashHitboxSpot.rotation);


            if (Upgrades.SecondaryUpgrade4) { 
            
                Vector3 BaseSize = firstdashexplosion.transform.localScale;

                BaseSize.x += SecondaryUpgrade4ExplosionSizeIncrease;
                BaseSize.y += SecondaryUpgrade4ExplosionSizeIncrease;
                BaseSize.z += SecondaryUpgrade4ExplosionSizeIncrease;


                firstdashexplosion.transform.localScale = BaseSize;
            
                Hitbox HB = firstdashexplosion.gameObject.GetComponent<Hitbox>();

                HB.Damage += SecondaryUpgrade4ExplosionDamageIncrease;
            
            }

        }


        float timer = 0f;
        float puddletimer = 0f;

        Vector3 Dir = transform.forward;

        Rigidbody rb = GetComponent<Rigidbody>();

    

        while (timer < DashTime) {


            timer += Time.deltaTime;

            if (Upgrades.SecondaryUpgrade1)
            {
                puddletimer += Time.deltaTime;

                if (puddletimer >= TimeBetweenPuddles) {

                    puddletimer = 0f;
                    Instantiate(PoisonPuddle, PoisonPuddleSpot.position, PoisonPuddleSpot.rotation);
                }


            }

            if (Upgrades.SecondaryUpgrade2) {

                speed += SecondaryUpgrade2DashSpeedIncrease;
            
            }

            if (!Upgrades.SecondaryUpgrade2)
            {
                transform.rotation.SetLookRotation(Dir);


            }

            else {

                Dir = transform.forward;


            }


            rb.linearVelocity = Dir * DashSpeed;


            yield return null;
        
        }

        AH.CanAttack = true;

        if (Upgrades.SecondaryUpgrade3)
        {

            GameObject seconddashexplosion = Instantiate(DashExplosion, DashHitboxSpot.position, DashHitboxSpot.rotation);

            if (Upgrades.SecondaryUpgrade4)
            {

                Vector3 BaseSize = seconddashexplosion.transform.localScale;

                BaseSize.x += SecondaryUpgrade4ExplosionSizeIncrease;
                BaseSize.y += SecondaryUpgrade4ExplosionSizeIncrease;
                BaseSize.z += SecondaryUpgrade4ExplosionSizeIncrease;


                seconddashexplosion.transform.localScale = BaseSize;

                Hitbox HB = seconddashexplosion.gameObject.GetComponent<Hitbox>();

                HB.Damage += SecondaryUpgrade4ExplosionDamageIncrease;



            }



        }


        Destroy(dashhitbot);

        




        StartCoroutine(DownTimeWaiter(SecondaryAttackDownTime,false));

    }



    public IEnumerator DownTimeWaiter(float Time, bool StopMove)
    {

        AH.CanAttack = false;


        if (StopMove)
        {
            PM.CanMove = false;
        }

        yield return new WaitForSeconds(Time);

        AH.CanAttack = true;


        PM.CanMove = true;



    }





}
