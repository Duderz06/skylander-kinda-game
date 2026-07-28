using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WizardEnemy : ShooterEnemy
{

    public float TeleportRange = 7f;
    public float HomeRange = 25f;
    public Vector3 HomePostion;


    private bool Started = false;

    void Start()
    {
        HomePostion = transform.position;
        base.Start();


    }

    // Update is called once per frame
    void Update()
    {


        if (Activated&&!Started)
        {

            Started=true;



            StartCoroutine(WizardStuff());


        }

        base.Update();


    }




    public IEnumerator WizardStuff()
    {

        while (true) {


            yield return StartCoroutine(Teleport());
            
            Vector3 dir = (Player.position - transform.position).normalized;
            dir.y = 0f;

            transform.rotation = Quaternion.LookRotation(dir);

            yield return new WaitForSeconds(WindupTime);

            StartCoroutine(Attack());

            yield return new WaitForSeconds(WindDownTime);

            yield return null;
        
        }





    }


    public IEnumerator Teleport() {

        bool CheckingSpot = true;

        while (CheckingSpot)
        {
            


            Vector3 RandDir = Random.insideUnitSphere * TeleportRange;
            RandDir.y = 0;
            Vector3 RandSpot = transform.position + RandDir;

            NavMeshHit hit;


            if (NavMesh.SamplePosition(RandSpot, out hit, 2f, NavMesh.AllAreas))
            {


                if (Vector3.Distance(HomePostion, hit.position) <= HomeRange)
                {

                    transform.position = hit.position;
                    CheckingSpot = false;

                }

            }



            yield return null;
        }


    }

}
