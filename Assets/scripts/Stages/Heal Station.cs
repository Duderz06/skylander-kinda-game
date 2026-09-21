using UnityEngine;

public class HealStation : MonoBehaviour
{

    public float HPToHeal = 25f;

    public bool DestroyOnTouch;


    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            PlayerHealthHandler PHH = other.GetComponent<PlayerHealthHandler>();

            PHH.HealHP(HPToHeal);

            if (DestroyOnTouch)
            {

                Destroy(gameObject);
            }


        }



    }





}
