using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Skeleton : MonoBehaviour
{


    private Transform Target;
    private NavMeshAgent NMA;
    private UpgradeHandler UH;

    public float Range = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        UH = FindAnyObjectByType<UpgradeHandler>();

        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Target = null;

        float ClosestDistance = Range;

        foreach (GameObject enemy in enemies) {

            if (Vector3.Distance(transform.position, enemy.transform.position)<=ClosestDistance) {

                ClosestDistance = Vector3.Distance(transform.position,enemy.transform.position);
                Target = enemy.transform;
            
            }
        
        }

        if (Target == null) { 
        
            Target = transform;

        }

        NMA.destination = Target.position;

    }



}
