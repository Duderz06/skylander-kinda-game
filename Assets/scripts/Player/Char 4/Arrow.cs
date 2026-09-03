using System.Collections;
using UnityEngine;

public class Arrow : Hitbox
{

    public int Pierces = 0;
    public int DieAfterPierces = 1;

    private Vector3 StartPos;
    private AttacksChar4 AC4;
    private UpgradeHandler Upgrades;

    void Start()
    {
        
        StartPos = transform.position;
        AC4 = FindAnyObjectByType<AttacksChar4>();
        Upgrades = FindAnyObjectByType<UpgradeHandler>();

    }

    public override void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {


            float Dist = Vector3.Distance(transform.position, StartPos);

            if (Dist >= AC4.Distances[0] && Upgrades.Passive) {

                if (Dist >= AC4.Distances[1]) { 
                
                    if (Dist >= AC4.Distances[2]) {

                        if (Dist >= AC4.Distances[3])
                        {

                            if (Dist >= AC4.Distances[4])
                            {

                                Damage += AC4.DistDamages[4];

                            }

                            else {

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





            Pierces++;
           
            StartCoroutine(CheckPierces());

        }




    }


 


    public IEnumerator CheckPierces() {

        yield return null;

        if (Pierces >= DieAfterPierces) { 
        
            Destroy(gameObject);
        
        }
    
    }

}
