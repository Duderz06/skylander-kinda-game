using System.Collections;
using UnityEngine;

public class LeechLifeGhost : MonoBehaviour
{

    public float HPToHeal = 5;

    private Transform Player;
    private Rigidbody RB;

    public float BaseSpeed = 5f;
    public float SpeedPerSecond = 2f;

    private PlayerHealthHandler PHH;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        PHH = Player.GetComponent<PlayerHealthHandler>();
        RB = GetComponent<Rigidbody>();

        StartCoroutine(GoToPlayer());

    }


    public IEnumerator GoToPlayer()
    {


        float Speed = BaseSpeed;

        while (true)
        {

            Vector3 dir = (Player.position - transform.position).normalized;

            RB.linearVelocity = dir * Speed;

            Speed += Time.deltaTime * SpeedPerSecond;


            yield return null;

        }



    }



    public void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Player"))
        {

            PHH.HealHP(HPToHeal);

            Destroy(gameObject);

        }

    }

}
