using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class NecroTurret : MonoBehaviour
{

    public float Damage = 4f;
    public float PassiveDamageIncrease = 1f;

    public float BulletSpeed = 3f;
    public float PassiveSpeedIncrease = 2f;

    public float DownTime = 1f;

    public float Range = 15f;

    public float LifeTime = 7f;

    private UpgradeHandler Upgrades;
    private GameObject Player;
    private AttacksChar7 AC7;

    public Transform ShotSpot;
    public GameObject Bullet;

    private bool CanShoot = true;


    private bool CanAura = true;
    public float AuraDamage = 1f;
    public float AuraDownTime = 0.5f;
    public float AuraRange = 10f;
    public float PassiveAuraDamageIncrease = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrades = FindAnyObjectByType<UpgradeHandler>();
        Player = Upgrades.gameObject;
        AC7 = Player.GetComponent<AttacksChar7>();

        StartCoroutine(DestoryAfterTime());


    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform Target = null;

        float ClosestDistance = Range;

        foreach (GameObject enemy in enemies)
        {

            if (Vector3.Distance(transform.position, enemy.transform.position) <= ClosestDistance)
            {

                ClosestDistance = Vector3.Distance(transform.position, enemy.transform.position);
                Target = enemy.transform;

            }

        }

        if (Target != null) {


            Vector3 Dir = Target.position - transform.position;
            Dir.y = 0;

            transform.rotation = Quaternion.LookRotation(Dir);


            if (CanShoot)
            {

                GameObject shot = Instantiate(Bullet, ShotSpot.position, ShotSpot.rotation);

                Hitbox HB = shot.GetComponent<Hitbox>();

                FireballScript FBS = shot.GetComponent<FireballScript>();


                float damage = Damage;

                float speed = BulletSpeed;


                if (Upgrades.SecondaryUpgrade4)
                {


                    HB.DestroyOnHit = false;
                    HB.InflictDOT = true;

                }

                if (Upgrades.Passive && Vector3.Distance(transform.position, Player.transform.position) <= AC7.PassiveRange) {

                    damage += PassiveDamageIncrease;

                    speed += PassiveSpeedIncrease;


                    
                }

               


                HB.Damage = damage;

                FBS.ForwardSpeed = speed;

                StartCoroutine(ShotDownTimer());

            }
        
        }


        

        if (Upgrades.SecondaryUpgrade2 && enemies.Length > 0 && CanAura) {


            foreach (GameObject enemy in enemies)
            {

                if (Vector3.Distance(transform.position, enemy.transform.position) <= AuraRange)
                {

                    EnemyParent EP = enemy.GetComponent<EnemyParent>();

                    float damage = AuraDamage;


                    if (Upgrades.Passive && Vector3.Distance(transform.position, Player.transform.position) <= AC7.PassiveRange)
                    {

                        damage += PassiveAuraDamageIncrease;


                    }

                    EP.TakeDamage(damage);

                    StartCoroutine(AuraDownTimer());

                }

            }




            



        }




    }


    public IEnumerator DestoryAfterTime()
    {
        yield return new WaitForSeconds(LifeTime);


        AC7.CreatedTurrets.Remove(gameObject);

        Destroy(gameObject);



    }



    public IEnumerator ShotDownTimer()
    {
        CanShoot = false;

        yield return new WaitForSeconds(DownTime);


        CanShoot = true;

    }

    public IEnumerator AuraDownTimer()
    {
        CanAura = false;

        yield return new WaitForSeconds(AuraDownTime);


        CanAura = true;

    }

}
