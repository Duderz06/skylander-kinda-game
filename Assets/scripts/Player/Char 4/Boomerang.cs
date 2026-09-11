using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{

    public float DistanceThrown = 5f;
    public float Speed = 5f;
    public float IncreaseInSpeedBack = 0.1f;

    private AttacksChar4 AC4;
    private UpgradeHandler Upgrades;
    private Rigidbody RB;

    public float StayAtEndTime = 1f;


    private Transform Player;

    void Start()
    {

        AC4 = FindAnyObjectByType<AttacksChar4>();
        Upgrades = FindAnyObjectByType<UpgradeHandler>();
        RB = GetComponent<Rigidbody>();


        Player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(Thrown());
    }

    // Update is called once per frame
    void Update()
    {

        



        
    }



    public IEnumerator Thrown() {

        Vector3 Dir = transform.forward;
        Dir.y = 0;
        Dir = Dir.normalized;

        Vector3 SpotToGoTo = transform.position + (Dir * DistanceThrown);


        while (Vector3.Distance(transform.position, SpotToGoTo) > 0.1f) {

            transform.position = Vector3.MoveTowards(transform.position, SpotToGoTo, Speed * Time.deltaTime);
        
        

            yield return null;
        }

        RB.linearVelocity = Vector3.zero;

        yield return new WaitForSeconds(StayAtEndTime);

        float BackSpeed = Speed;
        while (Vector3.Distance(transform.position, Player.position) > 0.1f)
        {

            transform.position = Vector3.MoveTowards(transform.position, Player.position, BackSpeed * Time.deltaTime);

            BackSpeed += IncreaseInSpeedBack;

            yield return null;
        }


        AC4.BoomerangBack = true;

        Destroy(gameObject);

    }






}
