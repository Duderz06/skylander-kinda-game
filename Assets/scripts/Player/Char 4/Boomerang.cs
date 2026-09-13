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

    public float ShieldSpeed = 10f;
    public float ShieldTime = 1f;
    public float ShieldDistance = 0.25f;

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



        if (Upgrades.SecondaryUpgrade3)
        {


            StartCoroutine(BoomerangShield());


        }

        else
        {
            Destroy(gameObject);
        }


    }



    public IEnumerator BoomerangShield()
    {
        float Timer = 0f;


        Vector3 StartDir = (transform.position - Player.position).normalized;

        if (StartDir == Vector3.zero) 
        { 
            StartDir = Vector3.forward; 
        
        
        }

        float Angle = Mathf.Atan2(StartDir.z, StartDir.x) * Mathf.Rad2Deg;

        while (Timer <= ShieldTime)
        {
            Timer += Time.deltaTime;

            Angle += ShieldSpeed * Time.deltaTime;



            float Radian = Angle * Mathf.Deg2Rad;
            Vector3 Offset = new Vector3(Mathf.Cos(Radian), 0, Mathf.Sin(Radian)) * ShieldDistance;

            transform.position = Player.position + Offset;

           
            transform.Rotate(Vector3.up, ShieldSpeed * Time.deltaTime);


            yield return null;
        }


        Destroy(gameObject);
    }







}
