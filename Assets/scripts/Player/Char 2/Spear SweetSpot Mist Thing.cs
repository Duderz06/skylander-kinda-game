using System;
using UnityEngine;

public class SpearSweetSpotMistThing : MonoBehaviour
{

    public GameObject Mist;
    public float MistDOT = 3f;
    public bool ActivateMist = false;


    

    public void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Enemy")&& ActivateMist)
        {

            GameObject mist = Instantiate(Mist, transform.position, transform.rotation);
            Hitbox H = mist.GetComponent<Hitbox>();
            H.DOTDamage = MistDOT;

        }


    }










}
