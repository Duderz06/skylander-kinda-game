using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksChar7 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;

    [Header("Main Attack stuff")]

    public Transform Skel1SummonSpot;
    public Transform Skel2SummonSpot;
    public Transform Skel3SummonSpot;
    public GameObject Skeleton;
    public float MainAttackDownTime = 1f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade2DamageIncrease = 2f;
    public float MainUpgrade3DamageIncrease = 1f;
    public float MainUpgrade4DamageIncrease = 2f;

    [Header("Secondary Attack stuff")]
    public Transform TurretSummonSpot;
    public GameObject Turret;
    public float SecondaryAttackDownTime = 0.5f;

    public int AmountOfTurrets = 1;
    public List<GameObject> CreatedTurrets = new List<GameObject>();

    [Header("Secondary Attack Upgrade Changes")]

    public float SecondaryUpgrade1DamageIncrease = 3f;
    public int SecondaryUpgrade1AmountIncrease = 1;
    public float SecondaryUpgrade2DamageIncrease = 2f;


    [Header("passive stuff")]

    public float PassiveRange = 7f;



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


        List<GameObject> skeles = new List<GameObject>();
        List<SkelHitbox> skeleHB = new List<SkelHitbox>();



        if (Upgrades.MainUpgrade1)
        {


            GameObject skel1 = Instantiate(Skeleton, Skel2SummonSpot.position, Skel2SummonSpot.rotation);


            skeles.Add(skel1);
            skeleHB.Add(skel1.GetComponentInChildren<SkelHitbox>());

            GameObject skel2 = Instantiate(Skeleton, Skel3SummonSpot.position, Skel3SummonSpot.rotation);


            skeles.Add(skel2);
            skeleHB.Add(skel2.GetComponentInChildren<SkelHitbox>());


        }



        else
        {
            GameObject skel = Instantiate(Skeleton, Skel1SummonSpot.position, Skel1SummonSpot.rotation);


            skeles.Add(skel);
            skeleHB.Add(skel.GetComponentInChildren<SkelHitbox>());


        }



        if (Upgrades.MainUpgrade2)
        {

            foreach (SkelHitbox HB in skeleHB) {

                HB.Damage += MainUpgrade2DamageIncrease;
            
            }

        }


        if (Upgrades.MainUpgrade3)
        {

            foreach (SkelHitbox HB in skeleHB)
            {

                HB.Damage += MainUpgrade3DamageIncrease;

                HB.SpawnBones = true;
            }


        }


        if (Upgrades.MainUpgrade4) {

            foreach (SkelHitbox HB in skeleHB)
            {

                HB.Damage += MainUpgrade4DamageIncrease;

            }
        }



        StartCoroutine(DownTimeWaiter(MainAttackDownTime));


    }



    public override void SecondaryAttack()
    {

        GameObject MadeTurret = Instantiate(Turret, TurretSummonSpot.position, TurretSummonSpot.rotation);

        CreatedTurrets.Add(MadeTurret);

        float AllowedTurrets = AmountOfTurrets;

        if (Upgrades.SecondaryUpgrade1) {

            AllowedTurrets += SecondaryUpgrade1AmountIncrease;
        
        }

        if (CreatedTurrets.Count > AllowedTurrets) {

            Destroy(CreatedTurrets[0]);
            CreatedTurrets.RemoveAt(0);
        
        }

        StartCoroutine(DownTimeWaiter(SecondaryAttackDownTime));


    }



    public IEnumerator DownTimeWaiter(float Time) {

        AH.CanAttack = false;

        yield return new WaitForSeconds(Time);

        AH.CanAttack= true;


    
    }






}
