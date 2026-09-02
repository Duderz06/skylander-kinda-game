using System.Collections;
using TMPro;
using UnityEngine;

public class DPStester : EnemyParent
{

    private float DPS = 0f;

    void Start()
    {

        StartCoroutine(DPSOutput());
        base.Start();

    }

    public override void TakeDamage(float damage)
    {

        Hp -= damage;

        DPS += damage;


        GameObject dn = Instantiate(DamageNumber, DamageNumberSpot.position, Camera.main.transform.rotation);
        dn.GetComponent<TextMeshPro>().text = damage.ToString();
        if (Hp <= 0)
        {

            UH.GainXP(XPGiven);

            Destroy(gameObject);

        }


    }


    public override IEnumerator DOTHandler(float damage, float time)
    {


        float timer = 0f;

        float timerforDOT = 0f;

        while (timer < time)
        {

            timer += Time.deltaTime;

            timerforDOT += Time.deltaTime;

            if (timerforDOT >= 1f)
            {


                TakeDamage(damage);

                timerforDOT = 0;
            }



            yield return null;
        }



    }



    public override void ApplyDOT(float damage, float duration)
    {
        StartCoroutine(DOTHandler(damage, duration));
    }




    public IEnumerator DPSOutput() {

        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (DPS > 0)
            {

                Debug.Log($"DPS: {DPS:F1}");

                DPS = 0f;


            }


        }

    }

}
