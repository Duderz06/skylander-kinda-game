using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HellFire : MonoBehaviour
{

    public Transform Enemy = null;
    public float Speed = 5f;

    public float SpawnHeight = 15f;
    public float ValidDistanceFromEnemy = 15f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();


        StartCoroutine(SpawnSpot());

    }


   

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }


    }



    public IEnumerator SpawnSpot() { 
    
        bool ValidSpot=false;

        while (!ValidSpot) {


            Vector2 Circle = Random.insideUnitCircle * ValidDistanceFromEnemy;

            Vector3 TryPos = new Vector3(Enemy.position.x + Circle.x, Enemy.position.y, Enemy.position.z + Circle.y);

            NavMeshHit hit;


            if (NavMesh.SamplePosition(TryPos, out hit, 2f, NavMesh.AllAreas))
            {
                ValidSpot = true;

                rb.linearVelocity = Vector3.down * Speed;

                transform.position = new Vector3(hit.position.x, SpawnHeight, hit.position.z);
                rb.linearVelocity = Vector3.down * Speed;

             
            }


            yield return null;

        }



    }
    



}
