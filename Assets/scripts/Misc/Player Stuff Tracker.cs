using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuffTracker : MonoBehaviour
{

    public bool ShouldSpawnPlayer = true;
    public Transform PlayerSpawnSpot;
    
    private UpgradeHandler UH;

    public static int WhichCharacter = 0;
    public List <GameObject> Characters = new List<GameObject> ();

    public static float XPGained = 0f;
    public static int Level = 0;

    public static bool MainMove = true;
    public static bool SecondaryMove = false;
    public static bool Passive = false;

    public static bool MainUpgrade1 = false;
    public static bool MainUpgrade2 = false;
    public static bool MainUpgrade3 = false;
    public static bool MainUpgrade4 = false;

    public static bool SecondaryUpgrade1 = false;
    public static bool SecondaryUpgrade2 = false;
    public static bool SecondaryUpgrade3 = false;
    public static bool SecondaryUpgrade4 = false;

    public static bool FinalUpgrade1 = false;
    public static bool FinalUpgrade2 = false;
    public static bool UltimateUpgrade = false;


    public static bool ChoseTopPath1 = false;
    public static bool ChoseTopPath2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        UH = FindAnyObjectByType <UpgradeHandler>();

        if (ShouldSpawnPlayer)
        {

            Instantiate(Characters[WhichCharacter], PlayerSpawnSpot.position, PlayerSpawnSpot.rotation);


        }


        if (UH != null)
        {
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



        }


    }

    
}
