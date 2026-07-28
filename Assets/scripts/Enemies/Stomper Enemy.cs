using System.Collections;
using UnityEngine;

public class StomperEnemy : EnemyParent
{

    private bool StartedThing = false;

    [Header("child stuff")]
    private Rigidbody RB;

    public float YValueFloat = 10f;
    public float HorzDistanceMax = 15f;

    public float WaitToStartTime = 1f;
    public float HoverTime = 1f;
    public float SlamWaitTime = 1f;

    public float ToSpotTime = 0.3f;

    public float HitGroundRayLength = 0.01f;
    public float SlamSpeed = 5f;

    public LayerMask GroundLayer;
    public bool HitGround = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        RB = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    protected virtual void Update()
    {

        if (!Activated)
        {

            base.Update();



        }

        else if (!StartedThing) {


            StartedThing = true;
            StartCoroutine(Stomper());

        
        }

       



    }



    public IEnumerator Stomper()
    {
        yield return new WaitForSeconds(SlamWaitTime);


        while (true) { 
        
        


            
            float HorzDistanceToPlayer = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(Player.transform.position.x, 0, Player.transform.position.z));

            Vector3 Dir = (Player.transform.position - transform.position).normalized;

            Vector3 SpotToGoTo = Vector3.zero;

            if (HorzDistanceToPlayer > HorzDistanceMax) {

            
                SpotToGoTo = transform.position + (Dir*HorzDistanceMax);

                if (Physics.Raycast(Player.transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, GroundLayer))
                {

                    SpotToGoTo.y = hit.point.y + YValueFloat;

                }

            }

            else
            {

                SpotToGoTo = Player.transform.position;

                if (Physics.Raycast(Player.transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, GroundLayer))
                {

                    SpotToGoTo.y = hit.point.y + YValueFloat;

                }



            }

            float TimeMoving = 0f;
            Vector3 StartPos = transform.position;


            while (TimeMoving < ToSpotTime)
            {


                TimeMoving += Time.deltaTime;

                RB.MovePosition(Vector3.Lerp(StartPos, SpotToGoTo, TimeMoving / ToSpotTime));

                yield return null;

            }


            transform.position = SpotToGoTo;

            yield return new WaitForSeconds(HoverTime);

            RB.linearVelocity = new Vector3(0, -SlamSpeed, 0);

            HitGround = false;

            yield return new WaitUntil(() => HitGround);

            RB.linearVelocity = Vector3.zero;


            yield return null;

            yield return new WaitForSeconds(SlamWaitTime);

        }


    }


    private void OnTriggerEnter(Collider other)
    {

        if (((1 << other.gameObject.layer) & GroundLayer) != 0)
        {
            HitGround = true;
        }

    }

}
