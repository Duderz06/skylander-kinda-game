using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : EnemyParent
{
    [Header("child stuff")]

    public float AttackCooldown = 1.5f;
    public bool CanAttack=true;

    public bool CanMove = true;

    public float RangeEpsilon = 0.5f;

    public Transform HitboxSpot;
    public GameObject AttackHitbox;

    public float WindupTime = 0.25f;
    public float WindDownTime = 0.25f;

    public float HitboxOutTime = 0.25f;

    public float AttackRotateSpeed = 15f;

    private GameObject hitbox;

    public bool RunAway = false;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();

    }

    // Update is called once per frame
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

            if (distance <= StayDistance + RangeEpsilon && CanAttack)
            {


                StartCoroutine(Attack());

            }




        }
        else {

            base.Update();

        }


    }


    virtual public IEnumerator Attack() {

        CanMove = false;
        CanAttack = false;

        NMA.isStopped = true;


        NMA.updateRotation = false;
        Vector3 Dir = Player.position - transform.position;
        Dir.y = 0;


        if (Dir != Vector3.zero)
        {

            transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation(Dir), AttackRotateSpeed * Time.deltaTime);


        }


        yield return new WaitForSeconds(WindupTime);
        hitbox = Instantiate(AttackHitbox, HitboxSpot.position, HitboxSpot.rotation);

        DamagePlayerHitbox DPH = hitbox.GetComponent<DamagePlayerHitbox>();

        if (DPH == null)
        {
            DPH = hitbox.GetComponentInChildren<DamagePlayerHitbox>();
        }

        DPH.Damage = Damage;

        yield return new WaitForSeconds(WindDownTime);

        Destroy(hitbox);

        NMA.isStopped = false;
        NMA.updateRotation = true;

        StartCoroutine(Cooldown());

    }


    public IEnumerator Cooldown() {

        yield return new WaitForSeconds(AttackCooldown);

        CanAttack = true;


    }


}
