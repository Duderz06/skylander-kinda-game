using System.Collections;
using TMPro;
using UnityEngine;

public class HandBossHandHP : EnemyParent
{

    private HandBossAI HBAI;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        HBAI = FindAnyObjectByType<HandBossAI>();
        base.Start();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


   


    public override IEnumerator Death()
    {



        HBAI.Hands.Remove(gameObject);
        HBAI.HandsAlive--;




        if (CountToCounter)
        {
            TT.EnemiesKilled++;
        }

        yield return null;


        gameObject.SetActive(false);

    }



}
