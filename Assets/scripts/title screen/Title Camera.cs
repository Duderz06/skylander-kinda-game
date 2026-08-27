using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float RotateSpeed = 1f;

    public float DistanceToSnap = 0.1f;


    public List<Transform> CameraSpots = new List<Transform> ();
    public int CurrentSpot = 0;
    private int LastSpot = 0;


    private Coroutine DOTHINGY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentSpot != LastSpot) { 
        
            LastSpot = CurrentSpot;

            if (DOTHINGY != null) {

                StopCoroutine(DOTHINGY);
            
            }

            DOTHINGY = StartCoroutine(MoveToSpot());

        }

    }


    public IEnumerator MoveToSpot() { 
    
        while (Vector3.Distance(transform.position, CameraSpots[CurrentSpot].position) > DistanceToSnap){


            transform.position = Vector3.MoveTowards(transform.position, CameraSpots[CurrentSpot].position, MoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, CameraSpots[CurrentSpot].rotation, RotateSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, CameraSpots[CurrentSpot].position) < DistanceToSnap){ 
            
                transform.position = CameraSpots[CurrentSpot].position;
                transform.rotation = CameraSpots[CurrentSpot].rotation;

            
            }

             yield return null;

        }



    }

}
