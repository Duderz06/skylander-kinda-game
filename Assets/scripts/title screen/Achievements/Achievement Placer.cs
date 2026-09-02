using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementPlacer : MonoBehaviour
{

    public float XChange = 6f;

    public List <Transform> Acheivements = new List<Transform> ();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        foreach (Transform child in transform)
        {
            Acheivements.Add(child.transform);

        }

        Vector3 BaseSpot = transform.localPosition;


        for (int i = 0; i < Acheivements.Count; i++) { 
        

            Acheivements[i].localPosition = BaseSpot;

            BaseSpot.x += XChange;
        
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }




    

}
