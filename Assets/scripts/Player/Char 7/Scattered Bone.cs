using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatteredBone : MonoBehaviour
{

    public float LifeTime = 5f;

    public GameObject Skeleton;
    public Transform SkeletonSpot;

    private UpgradeHandler Upgrades;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrades = FindAnyObjectByType<UpgradeHandler>();

        StartCoroutine(DieAfterTime());
    }


    public IEnumerator DieAfterTime() { 
    
    
        yield return new WaitForSeconds(LifeTime);

        if (Upgrades.MainUpgrade4) { 
        
            Instantiate(Skeleton,SkeletonSpot.position,SkeletonSpot.rotation);

        
        }

        Destroy(gameObject);
    
    }
    
}
