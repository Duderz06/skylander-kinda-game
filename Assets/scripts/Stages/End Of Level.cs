using UnityEngine;

public class EndOfLevel : MonoBehaviour
{

    public GameObject RankScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player") )
        {

            EndLevel();


        }

    }

    public void EndLevel() { 
    
        RankScreen.SetActive(true);
        Time.timeScale = 0;
    
    }



}
