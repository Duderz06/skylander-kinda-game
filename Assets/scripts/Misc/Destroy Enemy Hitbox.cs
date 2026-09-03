using System;
using UnityEngine;

public class DestroyEnemyHitbox : MonoBehaviour
{

    public bool CanDestroy = false;
    public void OnTriggerEnter(Collider other)
    {
        if (CanDestroy)
        {
            DamagePlayerHitbox DPH = other.GetComponent<DamagePlayerHitbox>();
            if (DPH != null)
            {

                Destroy(DPH.gameObject);

            }
        }

    }

}
