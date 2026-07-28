using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ArenaHandler : MonoBehaviour
{

    public List<GameObject> Enemies = new List<GameObject> ();
    public List<GameObject> Walls = new List<GameObject> ();

    public bool DeactivateEnemiesOnStart = true;
    private bool HasActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in Walls) { 
        
            obj.SetActive (false);

        }

        if (DeactivateEnemiesOnStart)
        {

            foreach (GameObject en in Enemies)
            {

                en.SetActive(false);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {



        if (Enemies.Count <= 0 && HasActive)
        {

            DeactivateArena();

        }

        else {

            Enemies.RemoveAll(enemy => enemy == null);

        }


    }


    public void ActivateArena() {

        HasActive= true;

        foreach (GameObject obj in Walls)
        {

            obj.SetActive(true);

        }



        foreach (GameObject en in Enemies)
        {

            en.SetActive(true);

            EnemyParent EP = en.GetComponent<EnemyParent>();
            EP.Activated = true;

        }




    }



    public void DeactivateArena()
    {


        foreach (GameObject obj in Walls)
        {

            obj.SetActive(false);

        }

        Destroy(gameObject);
    }


    public void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player") && !HasActive) { 
        
            ActivateArena();
        
        
        }

    }


}
