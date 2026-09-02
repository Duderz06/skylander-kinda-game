using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyParent : MonoBehaviour
{
    private ThingyTracker TT;

    [Header("parent stuff")]

    public float Hp = 15f;
    public float Damage = 10f;
    public float ActivationRange = 10f;

    public float XPGiven = 5f;

    public Transform Player;
    public bool Activated = false;
    public float StayDistance = 3f;
    public NavMeshAgent NMA;

    public UpgradeHandler UH;

    public GameObject DamageNumber;
    public Transform DamageNumberSpot;

    public List <GameObject> XPOrbs = new List<GameObject> ();
    public List <float> XPOrbAmount = new List<float> ();

    public float XpForceMin = 3f;
    public float XpForceMax = 7f;
    public float MaxXpAngle = 45f;

    public bool Died=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        UH = Player.GetComponent<UpgradeHandler>();
        
        NMA = GetComponent<NavMeshAgent>();

        TT = FindAnyObjectByType<ThingyTracker>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (!Activated) {

            if (Vector3.Distance(transform.position, Player.position) <= ActivationRange) { 
            
                Activated = true;

            }


        }



    }


    public virtual void TakeDamage(float damage) {

        Hp -= damage;


        if (DamageNumber != null)
        {
            
            GameObject dn = Instantiate(DamageNumber, DamageNumberSpot.position, Camera.main.transform.rotation);
            dn.GetComponent<TextMeshPro>().text = damage.ToString();


        }



        if (Hp <= 0&&!Died) {

           
            Died= true;

            StartCoroutine(Death());

        
        }
    
    
    }


    public virtual IEnumerator DOTHandler(float damage, float time) {


        float timer = 0f;

        float timerforDOT = 0f;

        while (timer < time) {

            timer += Time.deltaTime;

            timerforDOT += Time.deltaTime;
            
            if (timerforDOT >= 1f) {


                TakeDamage(damage);

                timerforDOT = 0;
            }



            yield return null;
        }


    
    }



    public virtual void ApplyDOT(float damage, float duration)
    {
        StartCoroutine(DOTHandler(damage, duration));
    }


    public IEnumerator Death()
    {

        float XpSpawned = 0f;

        while (XpSpawned < XPGiven) {

            GameObject SpawnedOrb = null;

            float RemainingXP = XPGiven - XpSpawned;

            if (RemainingXP >= XPOrbAmount[2])
            {
                XpSpawned += XPOrbAmount[2];
                SpawnedOrb = Instantiate(XPOrbs[2], transform.position, transform.rotation);

            }


            else if (RemainingXP >= XPOrbAmount[1])
            {
                XpSpawned += XPOrbAmount[1];
                SpawnedOrb = Instantiate(XPOrbs[1], transform.position, transform.rotation);

            }


            else
            {
                XpSpawned += XPOrbAmount[0];
                SpawnedOrb = Instantiate(XPOrbs[0], transform.position, transform.rotation);

            }


            Rigidbody OrbRB = SpawnedOrb.GetComponent<Rigidbody>();


            //i stole this from online i have no clue how it works
            float Angle = Mathf.Acos(Random.Range(Mathf.Cos(MaxXpAngle * Mathf.Deg2Rad), 1f));
            float azimuth = Random.Range(0f, Mathf.PI * 2f);

            Vector3 direction = new Vector3(Mathf.Sin(Angle) * Mathf.Cos(azimuth), Mathf.Cos(Angle), Mathf.Sin(Angle) * Mathf.Sin(azimuth));

            float RandForce = Random.Range(XpForceMin, XpForceMax);

            OrbRB.AddForce(direction * RandForce, ForceMode.Impulse);



            yield return null;
        }


        TT.EnemiesKilled++;

        Destroy(gameObject);
    }




}
