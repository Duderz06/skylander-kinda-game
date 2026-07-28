using System.Collections;
using UnityEngine;

public class XpOrb : MonoBehaviour
{

    public float XP = 1f;

    public Transform Player;
    public UpgradeHandler UH;

    public float BaseSpeed = 5f;
    public float SpeedPerSecond=2f;

    public Rigidbody RB;

    bool Started=false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        RB = GetComponent<Rigidbody>();
        UH = FindAnyObjectByType<UpgradeHandler>();


    }

    // Update is called once per frame
    void Update()
    {
        




    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("XP Orb")&& !other.CompareTag("Enemy") && !Started) {

            Started = true;
            StartCoroutine(GoToPlayer());

        }

        if (other.CompareTag("Player")) {

            UH.GainXP(XP);

            Destroy(gameObject);

        }

    }



    public IEnumerator GoToPlayer() {


        float Speed=BaseSpeed;

        while (true) {

            Vector3 dir = (Player.position - transform.position).normalized;

            RB.linearVelocity = dir * Speed;

            Speed += Time.deltaTime * SpeedPerSecond;


            yield return null;
        
        }
    
    
    
    }


}
