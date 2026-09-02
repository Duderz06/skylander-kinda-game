using System.Collections;
using UnityEngine;

public class DamagePlayerHitbox : MonoBehaviour
{

    public float Damage=15f;

    public bool DestroyOnTouch=false;

    public float LifeTime = 0.25f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestoryAfterTime());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player")) {

            PlayerHealthHandler PHH = other.GetComponent<PlayerHealthHandler>();

            PHH.TakeDamage(Damage,transform);

            if (DestroyOnTouch) {

                Destroy(gameObject);            
            }


        }



    }


    public IEnumerator DestoryAfterTime()
    {
        yield return new WaitForSeconds(LifeTime);

        Destroy(gameObject);



    }

}
