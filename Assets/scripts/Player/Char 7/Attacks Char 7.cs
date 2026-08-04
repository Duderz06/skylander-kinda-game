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


    [Header("Secondary Attack Upgrade Changes")]

    public float SecondaryUpgrade1DamageIncrease = 3f;
    public float SecondaryUpgrade2DamageIncrease = 2f;
    




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

        /**
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
        */
    }



    public IEnumerator DownTimeWaiter(float Time) {

        AH.CanAttack = false;

        yield return new WaitForSeconds(Time);

        AH.CanAttack= true;


    
    }






}
