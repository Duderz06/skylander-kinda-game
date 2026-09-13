using UnityEngine;

public class BoomerangHitbox : Hitbox
{

    private AttacksChar4 AC4;
    private Vector3 StartPos;
    private UpgradeHandler Upgrades;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartPos = transform.position;
        AC4 = FindAnyObjectByType<AttacksChar4>();
        Upgrades = FindAnyObjectByType<UpgradeHandler>();


        base.Start();
        
    }

   


    public virtual void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {


            float Dist = Vector3.Distance(transform.position, StartPos);

            if (Dist >= AC4.Distances[0] && Upgrades.Passive)
            {

                if (Dist >= AC4.Distances[1])
                {

                    if (Dist >= AC4.Distances[2])
                    {

                        if (Dist >= AC4.Distances[3])
                        {

                            if (Dist >= AC4.Distances[4])
                            {

                                Damage += AC4.DistDamages[4];

                            }

                            else
                            {

                                Damage += AC4.DistDamages[3];


                            }
                        }
                        else
                        {

                            Damage += AC4.DistDamages[2];


                        }
                    }
                    else
                    {

                        Damage += AC4.DistDamages[1];


                    }

                }
                else
                {

                    Damage += AC4.DistDamages[0];


                }

            }





            EnemyParent EP = other.GetComponent<EnemyParent>();

            EP.TakeDamage(Damage);

            if (InflictDOT)
            {

                EP.ApplyDOT(DOTDamage, DOTTime);

            }


            if (LifeSteal)
            {

                PlayerHealthHandler PHH = FindAnyObjectByType<PlayerHealthHandler>();

                PHH.HealHP(Damage / 7.5f);

            }






            if (DestroyOnHit)
            {

                Destroy(ObjToDestroy);

            }

        }




    }


}
