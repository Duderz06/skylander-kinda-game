using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    public float MaxHp = 100f;
    public float Hp = 0;

    public bool CanTakeDamage = true;
    public bool IFrames=false;
    public float IFrameTime = 1f;

    public float DamageMult = 1f;

    public GameObject DamageNumber;
    public Transform DamageNumberSpot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Hp = MaxHp;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void TakeDamage(float damage, Transform damager) {


        if (CanTakeDamage)
        {
            Hp -= damage*DamageMult;

            GameObject dn = Instantiate(DamageNumber, DamageNumberSpot.position, Camera.main.transform.rotation);
            dn.GetComponent<TextMeshPro>().text = (damage * DamageMult).ToString();

            if (Hp <= 0)
            {

                Die();

            }

            else
            {

                StartCoroutine(IFrameHandler());


            }


        }

    }


    public void Die() {

        Debug.Log("death");
    
    }



    public IEnumerator IFrameHandler() { 
    
        CanTakeDamage = false;


        yield return new WaitForSeconds(IFrameTime);
    
        CanTakeDamage=true;
    
    }



    public void HealHP(float heal) {

        Hp += heal;

        if (Hp > MaxHp)
        {
            Hp = MaxHp;
        
        }
    
    
    }

}
