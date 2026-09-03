using System;
using UnityEngine;

public class Char3Parry : MonoBehaviour
{

    public bool CanDestroy = false;
    public GameObject ParryExplosion;
    private UpgradeHandler Upgrades;


    void Start()
    {
        Upgrades = FindAnyObjectByType<UpgradeHandler>();
       

    }

    public void OnTriggerEnter(Collider other)
    {
        if (CanDestroy)
        {
            Debug.Log("a");

            DamagePlayerHitbox DPH = other.GetComponent<DamagePlayerHitbox>();
            if (DPH != null)
            {
                Debug.Log("b");
                Destroy(DPH.gameObject);

                if (Upgrades.MainUpgrade4) {
                    Debug.Log("c");

                    Instantiate(ParryExplosion, transform.position, transform.rotation);
                
                }

            }
        }

    }

}
