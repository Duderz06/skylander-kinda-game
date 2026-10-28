using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    public GameObject SpawnEnemy(GameObject EnemyPrefab, Vector3 Position, Quaternion Rotation, Transform Parent)
    {

        if (EnemyPrefab == null)
        {
            return null;

        }

        GameObject enemy = Instantiate(EnemyPrefab, Position, Rotation, Parent);

        if (Parent != null) {
            enemy.transform.parent = Parent;
        }

        return enemy;

    }



    public GameObject SpawnEnemy(GameObject EnemyPrefab, Vector3 Position, Transform Parent) {

        return SpawnEnemy(EnemyPrefab, Position, Quaternion.identity, Parent);
    }

    public GameObject SpawnEnemy(int EnemyIndex, Vector3 Position, Transform Parent)
    {

        if (EnemyIndex < 0 || EnemyIndex >= EnemyPrefabs.Count)
        {
            return null;
        }


        return SpawnEnemy(EnemyPrefabs[EnemyIndex], Position, Parent);
    }



}
