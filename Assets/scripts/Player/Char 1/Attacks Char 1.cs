using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksChar1 : AttackParent
{

    private UpgradeHandler Upgrades;
    private AttackHandler AH;

    [Header("Main Attack stuff")]

    public Transform BiteSpot;
    public Transform BiteProjectionSpot;
    public GameObject BitePrefab;
    public float MainAttackDownTime = 0.5f;

    [Header("Main Attack Upgrade Changes")]

    public float MainUpgrade1DamageIncrease = 3f;
    public float MainUpgrade1SizeIncrease = 1f;
    public float MainUpgrade2DamageIncrease = 2f;
    public float MainUpgrade3ProjectionDamageMult = 0.75f;
    public float MainUpgrade3ProjectionSizeIncrease = 1f;
    public float MainUpgrade4DamageIncrease = 3f;
    public float MainUltimateUpgradeFireDamageIncrease = 2f;

    [Header("Secondary Attack stuff")]
    public Transform FireSpot;
    public GameObject FirePrefab;
    public GameObject FireballBigPrefab;
    public GameObject FireballSmallPrefab;
    public float SecondaryAttackDownTime = 0.5f;


    [Header("Secondary Attack Upgrade Changes")]

    public float SecondaryUpgrade1DamageIncrease = 3f;
    public float SecondaryUpgrade2SizeIncrease = 1f;
    public float SecondaryUpgrade2DamageIncrease = 2f;
    public float SecondaryUpgrade3FireballCount = 4f;
    public float SecondaryUpgrade3FireballSpeed = 4f;
    public float SecondaryUpgrade3FireballLifeTime = 1f;
    public float SecondaryUpgrade3SizeChange = 0.5f;
    public float SecondaryUpgrade3ArcSize = 180f;
    public float SecondaryUpgrade4DamageIncrease = 3f;
    public float SecondaryUpgrade4SizeIncrease = 3f;
    public float SecondaryUpgrade4FireballSizeIncrease = 3f;
    public float SecondaryUltimateUpgradeDotIncrease = 2f;




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

        GameObject BiteObj = Instantiate(BitePrefab, BiteSpot.position, BiteSpot.rotation);

        BiteObj.transform.parent = BiteSpot;

        Hitbox BiteScript = BiteObj.GetComponent<Hitbox>();

        if (Upgrades.MainUpgrade1) {

            BiteScript.Damage += MainUpgrade1DamageIncrease;

            Vector3 BaseSize = BiteObj.transform.localScale;

            Vector3 NewSize = new Vector3(BaseSize.x + MainUpgrade1SizeIncrease, BaseSize.y + MainUpgrade1SizeIncrease, BaseSize.z + MainUpgrade1SizeIncrease);

            BiteObj.transform.localScale = NewSize;

        }

        if (Upgrades.MainUpgrade2)
        {

            BiteScript.Damage += MainUpgrade2DamageIncrease;
            BiteScript.InflictDOT = true;

        }



        if (Upgrades.MainUpgrade4) {

            BiteScript.Damage += MainUpgrade4DamageIncrease;

            BiteScript.LifeSteal = true;

        }




        if (Upgrades.MainUpgrade3)
        {

            GameObject BiteProjectionObj = Instantiate(BiteObj, BiteProjectionSpot.position, BiteProjectionSpot.rotation);

            BiteProjectionObj.transform.parent = BiteProjectionSpot;

            Hitbox BiteProjectionScript = BiteProjectionObj.GetComponent<Hitbox>();

            BiteProjectionScript.Damage *= MainUpgrade3ProjectionDamageMult;



            Vector3 BaseSize = BiteProjectionObj.transform.localScale;

            Vector3 NewSize = new Vector3(BaseSize.x + MainUpgrade3ProjectionSizeIncrease, BaseSize.y + MainUpgrade3ProjectionSizeIncrease, BaseSize.z + MainUpgrade3ProjectionSizeIncrease);

            BiteProjectionObj.transform.localScale = NewSize;

            if (Upgrades.UltimateUpgrade)
            {

                BiteProjectionScript.DOTDamage += MainUltimateUpgradeFireDamageIncrease;


            }

        }


        if (Upgrades.UltimateUpgrade) {

            BiteScript.DOTDamage += MainUltimateUpgradeFireDamageIncrease;


        }


        StartCoroutine(DownTimeWaiter(MainAttackDownTime));


    }



    public override void SecondaryAttack()
    {

        GameObject FireObj = Instantiate(FirePrefab, FireSpot.position, FireSpot.rotation);

        FireObj.transform.parent = FireSpot;

        Hitbox FireScript = FireObj.GetComponent<Hitbox>();



        GameObject BigFireBall = null;

        List<GameObject> SmallFireBalls = new List<GameObject>();


        if (Upgrades.SecondaryUpgrade1)
        {

            FireScript.Damage += SecondaryUpgrade1DamageIncrease;

            BigFireBall = Instantiate(FireballBigPrefab, FireSpot.position, FireSpot.rotation);

            if (Upgrades.UltimateUpgrade)
            {

                BigFireBall.GetComponent<Hitbox>().DOTDamage += SecondaryUltimateUpgradeDotIncrease;



            }

        }

        if (Upgrades.SecondaryUpgrade2)
        {

            FireScript.Damage += SecondaryUpgrade2DamageIncrease;

            Vector3 BaseSize = FireObj.transform.localScale;

            Vector3 NewSize = new Vector3(BaseSize.x + SecondaryUpgrade2SizeIncrease, BaseSize.y + SecondaryUpgrade2SizeIncrease, BaseSize.z + SecondaryUpgrade2SizeIncrease);

            FireObj.transform.localScale = NewSize;


        }

        if (Upgrades.SecondaryUpgrade3)
        {

            FireScript.Damage += SecondaryUpgrade1DamageIncrease;



            for (int i = 0; i < SecondaryUpgrade3FireballCount; i++) {


                GameObject SmallFireBall = Instantiate(FireballSmallPrefab, FireSpot.position, FireSpot.rotation);

                SmallFireBalls.Add(SmallFireBall);
                
                SmallFireBall.transform.localScale *= SecondaryUpgrade3SizeChange;

                FireballScript FBS = SmallFireBall.GetComponent<FireballScript>();
                FBS.ForwardSpeed = SecondaryUpgrade3FireballSpeed;


                Hitbox HB = SmallFireBall.GetComponent <Hitbox>();
                HB.LifeTime = SecondaryUpgrade3FireballLifeTime;

                if (Upgrades.UltimateUpgrade)
                {

                    HB.DOTDamage += SecondaryUltimateUpgradeDotIncrease;



                }

            }


            int Amount = SmallFireBalls.Count;

            for (int i = 0; i < Amount; i++)
            {
                float Angle;


                if (Amount == 1)
                {
                    Angle = 0;


                }


                else
                {
                    Angle = Mathf.Lerp(-SecondaryUpgrade3ArcSize / 2f,SecondaryUpgrade3ArcSize / 2f,(float)i / (Amount - 1));


                }


                SmallFireBalls[i].transform.localRotation = transform.rotation * Quaternion.Euler(0, Angle, 0);


            }



        }


        if (Upgrades.SecondaryUpgrade4)
        {

            FireScript.Damage += SecondaryUpgrade4DamageIncrease;

            Vector3 BaseSize = FireObj.transform.localScale;

            Vector3 NewSize = new Vector3(BaseSize.x + SecondaryUpgrade4SizeIncrease, BaseSize.y + SecondaryUpgrade4SizeIncrease, BaseSize.z + SecondaryUpgrade4SizeIncrease);

            FireObj.transform.localScale = NewSize;

            if (Upgrades.SecondaryUpgrade2) {


                Vector3 BigFireballBaseSize = BigFireBall.transform.localScale;

                Vector3 NewBigFireballSize = new Vector3(BaseSize.x + SecondaryUpgrade4FireballSizeIncrease, BaseSize.y + SecondaryUpgrade4FireballSizeIncrease, BaseSize.z + SecondaryUpgrade4FireballSizeIncrease);

                BigFireBall.transform.localScale = NewBigFireballSize;

            }


            if (Upgrades.SecondaryUpgrade3) {


                for (int i = 0; i < SecondaryUpgrade3FireballCount; i++)
                {

                    Vector3 SmallFireballBaseSize = SmallFireBalls[i].transform.localScale;

                    Vector3 NewSmallFireballSize = new Vector3((BaseSize.x + SecondaryUpgrade4FireballSizeIncrease)/2, (BaseSize.y + SecondaryUpgrade4FireballSizeIncrease) / 2, (BaseSize.z + SecondaryUpgrade4FireballSizeIncrease) / 2);

                    SmallFireBalls[i].transform.localScale = NewSmallFireballSize;

                }



            }

        }

        if (Upgrades.UltimateUpgrade)
        {

            FireScript.DOTDamage += SecondaryUltimateUpgradeDotIncrease;

            

        }

        StartCoroutine(DownTimeWaiter(SecondaryAttackDownTime));

    }



    public IEnumerator DownTimeWaiter(float Time) {

        AH.CanAttack = false;

        yield return new WaitForSeconds(Time);

        AH.CanAttack= true;


    
    }






}
