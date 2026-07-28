using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ShooterEnemy : BasicEnemy
{
    [Header("child stuff")]

    public int AmountOfShots = 1;
    public float ArcSize = 180f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        base.Update();




    }


    public override IEnumerator Attack() {

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
        List <GameObject> shots = new List<GameObject> ();


        for (int i = 0; i < AmountOfShots; i++) {
            float Angle = 0;

            if (AmountOfShots > 1)
            {
                Angle = Mathf.Lerp(-ArcSize / 2f, ArcSize / 2f, (float)i / (AmountOfShots - 1));
            }


            GameObject Shot = Instantiate(AttackHitbox, HitboxSpot.position, HitboxSpot.rotation);

            Shot.transform.localRotation = transform.rotation * Quaternion.Euler(0, Angle, 0);

            shots.Add(Shot);

        }

        foreach (GameObject Shot in shots)
        {
            DamagePlayerHitbox DPH = Shot.GetComponent<DamagePlayerHitbox>();
            DPH.Damage = Damage;
            DPH.LifeTime = HitboxOutTime;
        }


        yield return new WaitForSeconds(WindDownTime);

        

        NMA.isStopped = false;
        NMA.updateRotation = true;

        StartCoroutine(Cooldown());

    }


    public IEnumerator Cooldown() {

        yield return new WaitForSeconds(AttackCooldown);

        CanAttack = true;


    }


}
