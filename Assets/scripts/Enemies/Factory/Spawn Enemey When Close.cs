using System.Collections;
using UnityEngine;

public class SpawnEnemyWhenClose : MonoBehaviour
{

    private EnemySpawner ES;

    private Transform Player;
    
    public int WhichEnemy = 0;


    public float DistToSpawn = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ES = FindAnyObjectByType<EnemySpawner>();

        Player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(PlayerCheck());

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public IEnumerator PlayerCheck() {

        while (Vector3.Distance(transform.position,Player.position)>DistToSpawn) { 
        
        
            yield return null;
        }


        SpawnEnemy();

        yield return null;

        while (true) {


            if (transform.childCount < 1) {

                Destroy(gameObject);
            
            }



            yield return null;
        
        
        }

    }


    public void SpawnEnemy() {


        ES.EnemyNum = WhichEnemy;
        ES.SpawnPoint = transform;
        ES.Spawn(transform);

    }

}
