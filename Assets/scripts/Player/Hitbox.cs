using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    public float Damage = 5f;

    public float LifeTime = 0.25f;

    public bool DestroyOnHit = false;

    public bool InflictDOT=false;
    public float DOTDamage = 0f;
    public float DOTTime = 0f;


    public bool LifeSteal=false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(DestoryAfterTime());

    }

    // Update is called once per frame
    void Update()
    {
        


    }


    public IEnumerator DestoryAfterTime()
    {
        yield return new WaitForSeconds(LifeTime);

        Destroy(gameObject);



    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy")) {


            EnemyParent EP = other.GetComponent<EnemyParent>();

            EP.TakeDamage(Damage);

            if (InflictDOT) {

               EP.ApplyDOT(DOTDamage,DOTTime);
            
            }


            if (LifeSteal) {

                PlayerHealthHandler PHH = FindAnyObjectByType<PlayerHealthHandler>();

                PHH.HealHP(Damage / 7.5f);

            }






            if (DestroyOnHit) { 
            
                Destroy(gameObject);
            
            }

        }




    }

}
