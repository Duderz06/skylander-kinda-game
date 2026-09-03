using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttacksChar3 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;
    private PlayerMovement PM;


    [Header("Main Attack stuff")]

    public Transform SlashSpot;
    public GameObject Slash;
    public GameObject SlashBeam;
    public float DownTime = 0.25f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade1DamageIncrease = 2f;
    public float MainUpgrade2DamageIncrease = 1f;
    public float MainUpgrade2DownTimeDecrease = 0.1f;
    public float MainUpgrade3DamageIncrease = 2f;

    public float MainFinalUpgradeDamageIncrease = 2f;
    public float MainUltimateUpgradeDamageIncrease = 2f;
    public float MainUltimateUpgradeSizeIncrease = 1f;
    public float MainUltimateUpgradeDownTimeDecrease = 0.1f;



    [Header("Secondary Attack stuff")]

    public bool Holding=false;
    public float ChargePerSecond = 5f;
    public float ChargeMax = 10f;
    public float ChargeDashSpeed = 10f;
    public float SpinDownTime = 1f;
    public Transform SpinSlashSpot;
    public GameObject SpinAttack;
    public GameObject SpinWind;


    [Header("Secondary Attack Upgrade Changes")]

    public float SecondaryUpgrade1DamageIncrease = 3f;
    public float SecondaryUpgrade2DamageIncrease = 2f;
    public float SecondaryUpgrade2ChargeSpeedIncrease = 2f;
    public float SecondaryUpgrade2DownTimeDecrease = 0.5f;
    public float SecondaryUpgrade3DamageIncrease = 2f;

    public float SecondaryFinalUpgradeDamageIncrease = 2f;
    public float SecondaryUltimateUpgradeDamageIncrease = 2f;
    public float SecondaryUltimateUpgradeChargeSpeedIncrease = 2f;
    public float SecondaryUltimateUpgradeSizeIncrease = 1.5f;





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

        List<GameObject> slashes = new List<GameObject>();

        GameObject slash = Instantiate(Slash, SlashSpot.position, SlashSpot.rotation);
        slash.transform.parent = SlashSpot;

        slashes.Add(slash);

        Hitbox beamHB = null;

        if (Upgrades.MainUpgrade1) {

            GameObject beam = Instantiate(SlashBeam, SlashSpot.position, SlashSpot.rotation);
            slashes.Add(beam);
            beamHB = beam.GetComponent<Hitbox>();

        }


       


        foreach (GameObject go in slashes) {

            Hitbox hb = go.GetComponent<Hitbox>();

            if (Upgrades.MainUpgrade1) {

                hb.Damage += MainUpgrade1DamageIncrease;

                if (Upgrades.MainUpgrade2)
                {

                    hb.Damage += MainUpgrade2DamageIncrease;

                }

            }


            if (Upgrades.MainUpgrade3)
            {

                hb.Damage += MainUpgrade3DamageIncrease;

                Char3Parry C3P = go.GetComponent<Char3Parry>();
                if (C3P != null) {

                    C3P.CanDestroy = true;
                }

            }


            if (Upgrades.FinalUpgrade1) {

                hb.Damage += MainFinalUpgradeDamageIncrease;

                if (Upgrades.UltimateUpgrade) {


                    hb.Damage += MainUltimateUpgradeDamageIncrease;

                    Vector3 BaseSize = hb.gameObject.transform.localScale;

                    hb.gameObject.transform.localScale = new Vector3(BaseSize.x + MainUltimateUpgradeSizeIncrease, BaseSize.y, BaseSize.z + MainUltimateUpgradeSizeIncrease);


                }

            }





        }




        if (beamHB != null)
        {

            beamHB.Damage *= 0.5f;



        }


        StartCoroutine(SlashDownTime());
        StartCoroutine(DestroySlash(slash));



    }



    public override void SecondaryAttack()
    {

        Holding = true;
        StartCoroutine(ChargeSpinAttack());




    }



    public IEnumerator SlashDownTime() {

        AH.CanAttack = false;
        PM.CanMove = false;

        float time = DownTime;

        if (Upgrades.MainUpgrade2) {

            time -= MainUpgrade2DownTimeDecrease;

        }

        if (Upgrades.UltimateUpgrade) {

            time -= MainUltimateUpgradeDownTimeDecrease;

        }

        yield return new WaitForSeconds(time);

        AH.CanAttack = true;
        PM.CanMove = true;


    }

    public IEnumerator DestroySlash(GameObject slash) {

        float time = DownTime;

        if (Upgrades.MainUpgrade2)
        {

            time -= MainUpgrade2DownTimeDecrease;

        }

        if (Upgrades.UltimateUpgrade)
        {

            time -= MainUltimateUpgradeDownTimeDecrease;

        }
        yield return new WaitForSeconds(time/2);

        Destroy(slash);


        yield return new WaitForSeconds(time/2);



    }





    public IEnumerator ChargeSpinAttack()
    {

        float ChargeAmount = 0f;


        float ChargeAmountPerSecond = ChargePerSecond;


        if (Upgrades.SecondaryUpgrade2) {

            ChargeAmountPerSecond += SecondaryUpgrade2ChargeSpeedIncrease;

        }


        if (Upgrades.UltimateUpgrade) {

            ChargeAmountPerSecond += SecondaryUltimateUpgradeChargeSpeedIncrease;

        }


        while (Holding) {



            ChargeAmount += Time.deltaTime * ChargeAmountPerSecond;

            if (ChargeAmount > ChargeMax) {

                ChargeAmount = ChargeMax;

            }

             


            if (Input.GetMouseButtonUp(1)) {

                Holding = false;
                SpinAttackGo(ChargeAmount);
            
            }



            yield return null;


        }



    }


    public void SpinAttackGo(float ChargeAmount) {

        AH.CanAttack = false;
        PM.CanMove = false;

        

       

        GameObject SpinAttackObj = Instantiate(SpinAttack, SpinSlashSpot.position, SpinSlashSpot.rotation);
        GameObject spinwind = null;

        SpinAttackObj.transform.parent = SpinSlashSpot;

        Hitbox spinattackhitbox = SpinAttackObj.GetComponent<Hitbox>();
        Hitbox spinwinhitbox = null;

        if (Upgrades.SecondaryUpgrade1) {

            spinattackhitbox.Damage += SecondaryUpgrade1DamageIncrease;

            Vector3 dir = transform.forward;

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.linearVelocity = dir * ChargeDashSpeed;

            if (Upgrades.SecondaryUpgrade2)
            {

                spinattackhitbox.Damage += SecondaryUpgrade2DamageIncrease;
                

            }

        }

        if (Upgrades.SecondaryUpgrade3) {

            spinattackhitbox.Damage += SecondaryUpgrade3DamageIncrease;

            spinwind = Instantiate(SpinWind, SpinSlashSpot.position, SpinSlashSpot.rotation);

            spinwind.transform.parent = SpinSlashSpot;

            spinwinhitbox = spinwind.GetComponent<Hitbox>();

        }


     

        if (Upgrades.UltimateUpgrade)
        {

            spinattackhitbox.Damage += SecondaryUltimateUpgradeDamageIncrease;

            Vector3 basesize = SpinAttackObj.transform.localScale;

            SpinAttackObj.transform.localScale = new Vector3(basesize.x+SecondaryUltimateUpgradeSizeIncrease, basesize.y, basesize.z+ SecondaryUltimateUpgradeSizeIncrease);

            if (Upgrades.SecondaryUpgrade3 && spinwind != null) {

                basesize = spinwind.transform.localScale;

                spinwind.transform.localScale = new Vector3(basesize.x + SecondaryUltimateUpgradeSizeIncrease, basesize.y, basesize.z + SecondaryUltimateUpgradeSizeIncrease);



            }

        }


        float ChargePercent = ChargeAmount / ChargeMax;

        spinattackhitbox.Damage *= ChargePercent;


        StartCoroutine(SpinDownTimeWait());

    }


    public IEnumerator SpinDownTimeWait() {

        float time = SpinDownTime;

        if (Upgrades.SecondaryUpgrade2) {

            time -= SecondaryUpgrade2DownTimeDecrease;
        
        }

        yield return new WaitForSeconds(time);

        AH.CanAttack = true;
        PM.CanMove = true;

    }





}
