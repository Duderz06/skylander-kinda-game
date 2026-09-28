using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingyTracker : MonoBehaviour
{


    public static ThingyTracker Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }



    public int EnemiesInLevel = 0;
    public int EnemiesKilled = 0;

    public float TimeTaken = 0f;

    public float DamageTaken = 0f;




    public void StartTrackingStuff()
    {


        EnemiesInLevel = 0;
        EnemiesKilled = 0;
        TimeTaken = 0;
        DamageTaken = 0;

        StartCoroutine(Timer());
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        EnemiesInLevel = enemies.Length;
    }




    public IEnumerator Timer() {

        while (true) { 
        
            yield return new WaitForSeconds(1);
        
            TimeTaken++;
        
        }
    
    
    }



}
