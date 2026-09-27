using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class HandBossAI : MonoBehaviour
{

    public int HandsAlive = 2;

    public float TimeBetweenAttacks = 1.5f;


    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject Head;


    public Transform RightHandBaseSpot;
    public Transform LeftHandBaseSpot;
    public Transform HeadBaseSpot;
    public float ReturnToSpotSpeed = 5f;


    private Transform Player;




    [Header("Clap stuff")]

    public float ClapFollowPlayerTime = 2f;
    public float ClapHoverHandSpeed = 5f;
    public float ClapWaitTime = 1f;
    public float ClapSpeed = 3f;
    public float ClapStuckTime = 3f;

    public float ClapHoverAroundPlayerDistance = 5f;
    public float ClappedDistance = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(ClapAttack());

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public IEnumerator ClapAttack() {


        
        float timer = 0f;

        Vector3 MidPoint = Vector3.zero;

        while (timer<ClapFollowPlayerTime)
        {
            timer += Time.deltaTime;

            Vector3 RHandSpot = Player.transform.position;
            Vector3 LHandSpot = Player.transform.position;

            RHandSpot.x -= ClapHoverAroundPlayerDistance;
            LHandSpot.x += ClapHoverAroundPlayerDistance;



            RightHand.transform.position = Vector3.Lerp(RightHand.transform.position, RHandSpot, ClapHoverHandSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.Lerp(LeftHand.transform.position, LHandSpot, ClapHoverHandSpeed * Time.deltaTime);

            MidPoint = Player.transform.position;

            yield return null;
        }


        yield return new WaitForSeconds(ClapWaitTime);


        Vector3 RHandClappedSpot = MidPoint;
        Vector3 LHandClappedSpot = MidPoint;


        RHandClappedSpot.x -= ClappedDistance;
        LHandClappedSpot.x += ClappedDistance;



        while (RightHand.transform.position != RHandClappedSpot && LeftHand.transform.position != LHandClappedSpot) {

            RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RHandClappedSpot, ClapSpeed*Time.deltaTime);
            LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LHandClappedSpot, ClapSpeed*Time.deltaTime);



            yield return null;

        }


        yield return new WaitForSeconds(ClapStuckTime);



        while (RightHand.transform.position != RHandClappedSpot && LeftHand.transform.position != LHandClappedSpot)
        {

            RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RHandClappedSpot, ClapSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LHandClappedSpot, ClapSpeed * Time.deltaTime);



            yield return null;

        }




        while (RightHand.transform.position != RightHandBaseSpot.position || LeftHand.transform.position != LeftHandBaseSpot.position)
        {

            RightHand.transform.position = Vector3.MoveTowards(RightHand.transform.position, RightHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);
            LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftHandBaseSpot.position, ReturnToSpotSpeed * Time.deltaTime);


            yield return null;

        }



    }








}
