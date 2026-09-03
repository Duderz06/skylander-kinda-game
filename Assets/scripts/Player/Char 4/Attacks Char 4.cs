using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class AttacksChar4 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;

    [Header("Main Attack stuff")]

    public Transform ArrowSpot;
    public GameObject Arrow;
    public float MainAttackDownTime = 0.5f;
    public float ArcSize = 180f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade1DamageIncrease = 3f;
    public int MainUpgrade1PierceIncrease = 2;
    public float MainUpgrade3DamageIncrease = 1f;
    public int MainUpgrade3ShotIncrease = 2;

    [Header("Secondary Attack stuff")]
    public Transform BoomerangSpot;
    public GameObject Boomerang;
    
    public float SecondaryAttackDownTime = 0.5f;


    [Header("Secondary Attack Upgrade Changes")]

    public float SecondaryUpgrade2RangsIncrease = 1f;
    public float SecondaryUpgrade2DamageIncrease = 2f;
    public float SecondaryUpgrade3DamageIncrease = 1f;

    [Header("Passive Stuff")]

    public List<float> Distances = new List<float>();
    public List<float> DistDamages = new List<float>();




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


        List<GameObject> Arrows = new List<GameObject>();

        int ArrowsToShoot = 1;

        if (Upgrades.MainUpgrade3) {

            ArrowsToShoot += MainUpgrade3ShotIncrease;
        
        }

        for (int i = 0; i < ArrowsToShoot; i++)
        {
            float Angle = 0;

            if (ArrowsToShoot > 1)
            {
                Angle = Mathf.Lerp(-ArcSize / 2f, ArcSize / 2f, (float)i / (ArrowsToShoot - 1));
            }


            GameObject arrow = Instantiate(Arrow, ArrowSpot.position, ArrowSpot.rotation);

            arrow.transform.localRotation = transform.rotation * Quaternion.Euler(0, Angle, 0);

            Arrows.Add(arrow);

        }

        foreach (GameObject arrow in Arrows)
        {
            Arrow HB = arrow.GetComponent<Arrow>();




            if (Upgrades.MainUpgrade1)
            {

                HB.Damage += MainUpgrade1DamageIncrease;

                HB.DieAfterPierces += MainUpgrade1PierceIncrease;


            }

            if (Upgrades.MainUpgrade3) { 
            
                HB.Damage += MainUpgrade3DamageIncrease;
            
            
            }

        }


      

      

        StartCoroutine(DownTimeWaiter(MainAttackDownTime));


    }



    public override void SecondaryAttack()
    {
        /**
        GameObject FireObj = Instantiate(FirePrefab, FireSpot.position, FireSpot.rotation);

        FireObj.transform.parent = FireSpot;

        Hitbox FireScript = FireObj.GetComponent<Hitbox>();



       


        if (Upgrades.SecondaryUpgrade1)
        {

            FireScript.Damage += SecondaryUpgrade1DamageIncrease;

            BigFireBall = Instantiate(FireballBigPrefab, FireSpot.position, FireSpot.rotation);

           
        }

      
        */
        StartCoroutine(DownTimeWaiter(SecondaryAttackDownTime));

    }



    public IEnumerator DownTimeWaiter(float Time) {

        AH.CanAttack = false;

        yield return new WaitForSeconds(Time);

        AH.CanAttack= true;


    
    }






}
