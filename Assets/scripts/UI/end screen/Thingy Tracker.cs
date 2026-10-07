using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingyTracker : MonoBehaviour
{


    public static ThingyTracker Instance { get; private set; }


    private UpgradeHandler UH;
    public virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }



    public int EnemiesInLevel = 0;
    public int EnemiesKilled = 0;

    public float TimeTaken = 0f;

    public float DamageTaken = 0f;



    [Header("Player Upgrade Stuff")]


    public float XPGained = 0f;
    public int Level = 0;

    public bool MainMove = true;
    public bool SecondaryMove = false;
    public bool Passive = false;

    public bool MainUpgrade1 = false;
    public bool MainUpgrade2 = false;
    public bool MainUpgrade3 = false;
    public bool MainUpgrade4 = false;

    public bool SecondaryUpgrade1 = false;
    public bool SecondaryUpgrade2 = false;
    public bool SecondaryUpgrade3 = false;
    public bool SecondaryUpgrade4 = false;

    public bool FinalUpgrade1 = false;
    public bool FinalUpgrade2 = false;
    public bool UltimateUpgrade = false;


    public bool ChoseTopPath1 = false;
    public bool ChoseTopPath2 = false;




    public void StartTrackingStuff()
    {


        EnemiesInLevel = 0;
        EnemiesKilled = 0;
        TimeTaken = 0;
        DamageTaken = 0;

        StartCoroutine(Timer());
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        EnemiesInLevel = enemies.Length;
    }




    public IEnumerator Timer() {

        while (true) { 
        
            yield return new WaitForSeconds(1);
        
            TimeTaken++;
        
        }
    
    
    }





    public void UpdatePlayerUpgrades() {

        UH = FindAnyObjectByType<UpgradeHandler>();

        UH.XPGained = XPGained;
        UH.Level = Level;

        UH.MainMove = MainMove;
        UH.SecondaryMove = SecondaryMove;
        UH.Passive = Passive;

        UH.MainUpgrade1 = MainUpgrade1;
        UH.MainUpgrade2 = MainUpgrade2;
        UH.MainUpgrade3 = MainUpgrade3;
        UH.MainUpgrade4 = MainUpgrade4;

        UH.SecondaryUpgrade1 = SecondaryUpgrade1;
        UH.SecondaryUpgrade2 = SecondaryUpgrade2;
        UH.SecondaryUpgrade3 = SecondaryUpgrade3;
        UH.SecondaryUpgrade4 = SecondaryUpgrade4;

        UH.FinalUpgrade1 = FinalUpgrade1;
        UH.FinalUpgrade2 = FinalUpgrade2;
        UH.UltimateUpgrade = UltimateUpgrade;


        UH.ChoseTopPath1 = ChoseTopPath1;
        UH.ChoseTopPath2 = ChoseTopPath2;

        UH.UpdateXpBar();

    }



}
