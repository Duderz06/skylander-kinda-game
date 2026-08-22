using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingyTracker : MonoBehaviour
{

    private RankHandler RH;


    public int EnemiesInLevel = 0;
    public int EnemiesKilled = 0;

    public float TimeTaken = 0f;

    public float DamageTaken=0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        RH = FindAnyObjectByType<RankHandler>();

        StartCoroutine(Timer());


        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        EnemiesInLevel = enemies.Length;

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public IEnumerator Timer() {

        while (true) { 
        
            yield return new WaitForSeconds(1);
        
            TimeTaken++;
        
        }
    
    
    }



}
