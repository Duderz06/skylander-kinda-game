using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class HandBossAI : MonoBehaviour
{

    public int HandsAlive = 2;
    public List<GameObject> Hands = new List<GameObject>();

    public float TimeBetweenAttacks = 1.5f;
    private float Timer = 0f;

    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject Head;


    public Transform RightHandBaseSpot;
    public Transform LeftHandBaseSpot;
    public Transform HeadBaseSpot;
    public float ReturnToSpotSpeed = 5f;
    public Vector3 BaseHandRotation = Vector3.zero;
    public float HandRotateSpeed = 5f;

    private Transform Player;

    private bool Attacking = false;


    [Header("Clap stuff")]

    public float ClapFollowPlayerTime = 2f;
    public float ClapHoverHandSpeed = 5f;
    public float ClapWaitTime = 1f;
    public float ClapSpeed = 3f;
    public float ClapStuckTime = 3f;

    public float ClapHoverAroundPlayerDistance = 5f;
    public float ClappedDistance = 1f;

    public Vector3 RHandClapRotation;
    public Vector3 LHandClapRotation;



    [Header("Slam stuff")]
    public float SlamFollowPlayerTime = 2f;
    public float SlamHoverHandSpeed = 5f;
    public float SlamWaitTime = 1f;
    public float SlamStuckTime = 3f;
    public float SlamSpeed = 5f;
    public float SlamHoverAbovePlayerDistance = 5f;
    public float SlamDistanceFromGround = 1f;

    public Vector3 SlamHandRotation;



    [Header("Shockwave stuff")]
    public GameObject Shockwave;
    public Transform LeftHandShockSpot;
    public Transform RightHandShockSpot;
    public float ShockwaveSlamSpeed = 15f;
    public float ShockwaveHeightForHands = 5f;

    public float ShockwaveHandsStuckTime = 5f;
    public Vector3 ShockwaveHandRotation;
    public float ShockwavePrepTime = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        //StartCoroutine(ClapAttack());

    }

    // Update is called once per frame
    void Update()
    {

        if (!Attacking)
        {
            Timer += Time.deltaTime;

        }

        if (Timer >= TimeBetweenAttacks) {

            Timer = 0f;
            Attacking = true;

            int WhichAttack=0;


            if (HandsAlive == 2) {

                WhichAttack = Random.Range(0, 2);

            }

            if (HandsAlive == 1) {

                WhichAttack = Random.Range(0, 1);

            }

            if (WhichAttack == 0)
            {

                GameObject HandToSlam;

                if (Hands.Count > 1)
                {
                    int WhichHand = Random.Range(0, 2);

                    if (WhichHand == 0)
                    {

                        HandToSlam = RightHand;

                    }

                    else
                    {

                        HandToSlam = LeftHand;

                    }

                }

                else
                {

                    HandToSlam = Hands[0];
                    Debug.Log("d");


                }


                StartCoroutine(SlamAttack(HandToSlam));


            }


            else if (WhichAttack == 1) {


                StartCoroutine(ClapAttack());



            }



        }




    }



    public IEnumerator ClapAttack() {



        float timer = 0f;

        Vector3 MidPoint = Vector3.zero;

        while (timer < ClapFollowPlayerTime)
        {
            timer += Time.deltaTime;

            Vector3 RHandSpot = Player.transform.position;
            Vector3 LHandSpot = Player.transform.position;

            RHandSpot.x -= ClapHoverAroundPlayerDistance;
            LHandSpot.x += ClapHoverAroundPlayerDistance;
            


            RightHand.transform.position = Vector3.Lerp(RightHand.transform.position, RHandSpot, ClapHoverHandSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.Lerp(LeftHand.transform.position, LHandSpot, ClapHoverHandSpeed * Time.deltaTime);

            RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, Quaternion.Euler(RHandClapRotation), HandRotateSpeed * Time.deltaTime);
            LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, Quaternion.Euler(LHandClapRotation), HandRotateSpeed * Time.deltaTime);



            MidPoint = Player.transform.position;

            yield return null;
        }


        RightHand.transform.rotation = Quaternion.Euler(RHandClapRotation);
        LeftHand.transform.rotation = Quaternion.Euler(LHandClapRotation);

        yield return new WaitForSeconds(ClapWaitTime);


        Vector3 RHandClappedSpot = MidPoint;
        Vector3 LHandClappedSpot = MidPoint;


        RHandClappedSpot.x -= ClappedDistance;
        LHandClappedSpot.x += ClappedDistance;



        while (RightHand.transform.position != RHandClappedSpot && LeftHand.transform.position != LHandClappedSpot) {

            RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RHandClappedSpot, ClapSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LHandClappedSpot, ClapSpeed * Time.deltaTime);



            yield return null;

        }


        yield return new WaitForSeconds(ClapStuckTime);


        


        while (RightHand.transform.position != RightHandBaseSpot.position || LeftHand.transform.position != LeftHandBaseSpot.position)
        {

            RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RightHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);


            RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, Quaternion.Euler(BaseHandRotation), HandRotateSpeed * Time.deltaTime);
            LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, Quaternion.Euler(BaseHandRotation), HandRotateSpeed * Time.deltaTime);

            yield return null;

        }

        RightHand.transform.rotation = Quaternion.Euler(BaseHandRotation);
        LeftHand.transform.rotation = Quaternion.Euler(BaseHandRotation);

        Attacking = false;
    }



    public IEnumerator SlamAttack(GameObject Hand)
    {
        


        float timer = 0f;

        Vector3 HandSpot = Player.transform.position;

        while (timer < SlamFollowPlayerTime)
        {
            timer += Time.deltaTime;

            HandSpot = Player.transform.position;

            HandSpot.y += SlamHoverAbovePlayerDistance;



            Hand.transform.position = Vector3.Lerp(Hand.transform.position, HandSpot, SlamHoverHandSpeed * Time.deltaTime);


            Hand.transform.rotation = Quaternion.Lerp(Hand.transform.rotation, Quaternion.Euler(SlamHandRotation), HandRotateSpeed * Time.deltaTime);


            yield return null;
        }

        HandSpot.y = Player.transform.position.y;
        HandSpot.y += SlamDistanceFromGround;

        yield return new WaitForSeconds(SlamWaitTime);


        while (Hand.transform.position != HandSpot)
        {

            Hand.transform.position = Vector3.MoveTowards(Hand.transform.position, HandSpot, SlamSpeed * Time.deltaTime);



            yield return null;

        }


        yield return new WaitForSeconds(SlamStuckTime);




        while (RightHand.transform.position != RightHandBaseSpot.position || LeftHand.transform.position != LeftHandBaseSpot.position)
        {

            RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RightHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);


            RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, Quaternion.Euler(BaseHandRotation), HandRotateSpeed * Time.deltaTime);
            LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, Quaternion.Euler(BaseHandRotation), HandRotateSpeed * Time.deltaTime);


            yield return null;

        }


        RightHand.transform.rotation = Quaternion.Euler(BaseHandRotation);
        LeftHand.transform.rotation = Quaternion.Euler(BaseHandRotation);

        Attacking = false;
    }



    public IEnumerator ShockwaveAttack()
    {

        float timer = 0f;

        Vector3 RHandSpot = Player.transform.position;
        Vector3 LHandSpot = Player.transform.position;

        while (timer < ShockwavePrepTime)
        {
            timer += Time.deltaTime;

          

            RHandSpot = RightHandShockSpot.position;
            RHandSpot.y += ShockwaveHeightForHands;
            

            
            LHandSpot = LeftHandShockSpot.position;
            LHandSpot.y += ShockwaveHeightForHands;


            if (RightHand != null) {

                RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RHandSpot, ReturnToSpotSpeed * Time.deltaTime);
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, Quaternion.Euler(ShockwaveHandRotation), HandRotateSpeed * Time.deltaTime);



            }


            if(LeftHand != null) {

                LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LHandSpot, ReturnToSpotSpeed * Time.deltaTime);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, Quaternion.Euler(ShockwaveHandRotation), HandRotateSpeed * Time.deltaTime);



            }

            bool slammed = false;


            while (slammed)
            {

                if (RightHand != null)
                {
                    RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RHandSpot, ClapSpeed * Time.deltaTime);

                }

                if (LeftHand != null)
                {
                    LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LHandSpot, ClapSpeed * Time.deltaTime);
                }

                //figure out how to check if slammed if only 1 hand is alive and it still works with both
                yield return null;

            }






            yield return null;
        }


        //make shockwave that do thing
        // make it only on alive hands



        yield return new WaitForSeconds(ShockwaveHandsStuckTime);





        //figure out how to change this part to make it work if only 1 hand is alive
        while (RightHand.transform.position != RightHandBaseSpot.position || LeftHand.transform.position != LeftHandBaseSpot.position)
        {
            if (RightHand != null)
            {
                RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RightHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);
                RightHand.transform.rotation = Quaternion.Lerp(RightHand.transform.rotation, Quaternion.Euler(BaseHandRotation), HandRotateSpeed * Time.deltaTime);
            }


            if (LeftHand != null)
            {
                LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);
                LeftHand.transform.rotation = Quaternion.Lerp(LeftHand.transform.rotation, Quaternion.Euler(BaseHandRotation), HandRotateSpeed * Time.deltaTime);
            }

            yield return null;

        }



    }


}
