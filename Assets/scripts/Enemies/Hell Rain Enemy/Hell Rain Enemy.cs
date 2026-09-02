using System.Collections;
using UnityEngine;

public class HellRainEnemy : EnemyParent
{


    [Header("child stuff")]

    public float AttackCooldown = 1.5f;
    public bool CanAttack = true;

    public bool CanMove = true;

    public Transform HitboxSpot;
    public GameObject AttackHitbox;

    public float WindupTime = 0.25f;
    public float WindDownTime = 0.25f;

    private GameObject hitbox;

    public bool RunAway = false;

    public int AmountOfHellFire = 10;
    public float BetweenFireTime = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();

    }



    protected virtual void Update()
    {


        if (Activated)
        {

            NMA.destination = Player.position;

            float distance = Vector3.Distance(transform.position, Player.position);


            if (RunAway && distance < StayDistance)
            {
                Vector3 dir = (transform.position - Player.position).normalized;

                Vector3 spot = Player.position + StayDistance * dir;

                NMA.destination = spot;


            }

            if (CanAttack)
            {


                StartCoroutine(Attack());

            }




        }
        else
        {

            base.Update();

        }


    }




    virtual public IEnumerator Attack()
    {

        CanMove = false;
        CanAttack = false;

        NMA.isStopped = true;


        NMA.updateRotation = false;
       


        yield return new WaitForSeconds(WindupTime);

        for (int i = 0; i < AmountOfHellFire; i++)
        {

            hitbox = Instantiate(AttackHitbox, HitboxSpot.position, HitboxSpot.rotation);

            DamagePlayerHitbox DPH = hitbox.GetComponent<DamagePlayerHitbox>();

            HellFire HF = hitbox.GetComponent<HellFire>();

            if (DPH == null)
            {
                DPH = hitbox.GetComponentInChildren<DamagePlayerHitbox>();
            }

            HF.Enemy = transform;

            DPH.Damage = Damage;

            yield return new WaitForSeconds(BetweenFireTime);

        }


        yield return new WaitForSeconds(WindDownTime);


        NMA.isStopped = false;
        NMA.updateRotation = true;
        CanMove = true;

        StartCoroutine(Cooldown());

    }


    public IEnumerator Cooldown()
    {

        yield return new WaitForSeconds(AttackCooldown);

        CanAttack = true;


    }




}
