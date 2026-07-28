using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CamMoveToSpot : MonoBehaviour
{

    public float YChange = 6f;
    public float ZChange = -11.5f;
    public float MoveSpeed = 5f;

    private List<GameObject> Players = new List<GameObject> ();

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Players = GameObject.FindGameObjectsWithTag("Player").ToList();



    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 Midpoint = Vector3.zero;

        if (Players.Count > 1)
        {


            Vector3 Pos = Vector3.zero;


            foreach (var player in Players)
            {
                Pos += player.transform.position;


            }


            Midpoint = Pos / Players.Count;


        }


        else
        { 
        
            Midpoint = Players[0].transform.position;
        
        
        }



        Midpoint.y += YChange;
        Midpoint.z += ZChange;


        transform.position = Vector3.Lerp(transform.position, Midpoint, MoveSpeed);

        //transform.position = Midpoint;



    }



}
