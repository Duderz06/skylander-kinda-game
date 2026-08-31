using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Char3HpHandler : PlayerHealthHandler
{


    private UpgradeHandler UH;

    public float PassiveDamageMult = 0.5f;

    public float DifferenceForPassive = 45;


    private void Start()
    {
        UH = GetComponent<UpgradeHandler>();

 
        base.Start();




    }




    public override void TakeDamage(float damage, Transform damager)
    {

        if (CanTakeDamage)
        {


            if (UH.Passive)
            {

                float angle = Vector3.Angle(damager.transform.forward, -transform.forward);

                if (angle <= DifferenceForPassive)
                {
                    DamageMult = PassiveDamageMult;
                }
                else {

                    DamageMult = 1f;

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

            TT.DamageTaken += damage;


        }
        UpdateHpBar();

    }










}
