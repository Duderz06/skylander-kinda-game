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
    public bool BufferedSecondDash=false;
    public bool DoingDash=false;
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
    public float SecondaryUpgrade3DamageIncrease = 2f;
    public float SecondaryUpgrade3PuddleDOTIncrease = 2f;
    
    




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

        Debug.Log("a");
      
        GameObject dashhitbot = Instantiate(DashHitbox, DashHitboxSpot.position, DashHitboxSpot.rotation);

        dashhitbot.transform.parent = DashHitboxSpot;


        if (!DoingDash)
        {
            DashesSoFar = 0;

            DashesSoFar++;
            Debug.Log("b");

            StartCoroutine(Dashing(dashhitbot));
        }

        else if (Upgrades.SecondaryUpgrade2 && DashesSoFar<2) {
        
            //never getting c
            Debug.Log("c");

            DashesSoFar++;

            BufferedSecondDash = true;

        }


    }

    //cannot figure out the double dash thing help asdasdasd
    public IEnumerator Dashing(GameObject dashhitbot) {

        DoingDash = true;
        Debug.Log("d");

        AttackHandler AH = GetComponent<AttackHandler>();

        
        AH.CanAttack = false;

        
        if (Upgrades.SecondaryUpgrade3)
        {

            GameObject firstdashexplosion = Instantiate(DashExplosion, DashHitboxSpot.position, DashHitboxSpot.rotation);

        }

        float timer = 0f;
        float puddletimer = 0f;

        Vector3 Dir = transform.forward;

        Rigidbody rb = GetComponent<Rigidbody>();

    

        while (timer < DashTime) {

            Debug.Log("e");



            timer += Time.deltaTime;

            if (Upgrades.SecondaryUpgrade1)
            {
                puddletimer += Time.deltaTime;

                if (puddletimer >= TimeBetweenPuddles) {

                    puddletimer = 0f;
                    Instantiate(PoisonPuddle, PoisonPuddleSpot.position, PoisonPuddleSpot.rotation);
                }


            }



            transform.rotation.SetLookRotation(Dir);

            rb.linearVelocity = Dir*DashSpeed;

            yield return null;
        
        }
        AH.CanAttack = true;

        if (Upgrades.SecondaryUpgrade3)
        {

            GameObject seconddashexplosion = Instantiate(DashExplosion, DashHitboxSpot.position, DashHitboxSpot.rotation);

        }
        Destroy(dashhitbot);

        
        if (BufferedSecondDash) {
            //never getting f
            Debug.Log("f");

            BufferedSecondDash = false;

            StartCoroutine(Dashing(dashhitbot));

        }

        if (DashesSoFar >= 2) { 
        
            DashesSoFar=0;

            //never getting g
            Debug.Log("g");

        }


        DoingDash = false;



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
