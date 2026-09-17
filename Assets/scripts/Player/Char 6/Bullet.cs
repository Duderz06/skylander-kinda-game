using UnityEngine;

public class Bullet : Hitbox
{

    private AttacksChar6 AC6;
    private UpgradeHandler UH;

    public bool IsCrit = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        base.Start();

         AC6 = FindAnyObjectByType<AttacksChar6>();
        UH = FindAnyObjectByType<UpgradeHandler>();

    }

    public override void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {


            EnemyParent EP = other.GetComponent<EnemyParent>();

            EP.TakeDamage(Damage);


            if (!IsCrit && UH.MainUpgrade3)
            {

                AC6.MainUpgrade3AddedCritChance += AC6.MainUpgrade3CritChanceAdded;



            }
            else {
                AC6.MainUpgrade3AddedCritChance = 0;
            }




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

                Destroy(gameObject);

            }

        }




    }


}
