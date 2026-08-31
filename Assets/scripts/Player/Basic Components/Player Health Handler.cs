using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public ThingyTracker TT;

    private Image HPBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Hp = MaxHp;
        TT = FindAnyObjectByType<ThingyTracker>();

        HPBar = GameObject.Find("hp bar").GetComponent<Image>();
        UpdateHpBar();

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

            TT.DamageTaken += damage;
            

        }

        UpdateHpBar();
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

        UpdateHpBar();
    }


    public void UpdateHpBar() {

        HPBar.fillAmount = Hp / MaxHp;
    
    
    }

}
