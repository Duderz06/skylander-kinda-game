using UnityEngine;

public class EnemySpawner : MonoBehaviour
{



    public EnemyFactory EF;
    public Transform SpawnPoint;

    public int EnemyNum = 0;

    public void Spawn(Transform Parent)
    {

        if (EF == null || SpawnPoint == null)
        { 
            return; 
        }

        EF.SpawnEnemy(EnemyNum, SpawnPoint.position, Parent);


    }



}
