using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Char1HpHandler : PlayerHealthHandler
{

    public GameObject Thorns;

    private UpgradeHandler UH;

    public float PassiveDamageMult = 0.75f;
    public float UltimateUpgradeThornsDamageIncrease = 1.25f;
    public float UltimateUpgradeThornsSizeIncrease = 1.25f;
    public float UltimateUpgradeDamageMult = 0.55f;


    private void Start()
    {
        UH = GetComponent<UpgradeHandler>();

 
        base.Start();




    }




    public override void TakeDamage(float damage,Transform damager)
    {

        if (CanTakeDamage)
        {


            if (UH.Passive)
            {

                GameObject thorns = Instantiate(Thorns, transform.position, transform.rotation);

                thorns.transform.parent = transform;


                Hitbox HB = Thorns.GetComponent<Hitbox>();

                HB.Damage = damage;


                DamageMult = PassiveDamageMult;

                if (UH.UltimateUpgrade) { 
                
                    HB.InflictDOT = true;


                    HB.Damage = damage * UltimateUpgradeThornsDamageIncrease;

                    Vector3 BaseSize = thorns.transform.localScale;

                    thorns.transform.localScale = new Vector3(BaseSize.x + UltimateUpgradeThornsSizeIncrease, BaseSize.y+ UltimateUpgradeThornsSizeIncrease, BaseSize.z+ UltimateUpgradeThornsSizeIncrease);


                    DamageMult = UltimateUpgradeDamageMult;

                }


            }


            GameObject dn = Instantiate(DamageNumber, DamageNumberSpot.position, Camera.main.transform.rotation);
            dn.GetComponent<TextMeshPro>().text = (damage * DamageMult).ToString();

            Hp -= damage * DamageMult;


           


            if (Hp <= 0)
            {

                Die();

            }

            else
            {

                StartCoroutine(IFrameHandler());


            }
        }

    }


    







}
