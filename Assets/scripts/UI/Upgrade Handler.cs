using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{

    public List<float> EXPNeededPerLevel = new List<float>();
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

    public GameObject UpgradePickerMenu;


    private Image XPBar;


    private void Awake()
    {
        UpgradePickerMenu = GameObject.Find("upgrade thing");
        XPBar = GameObject.Find("xp bar").GetComponent<Image>();
        UpdateXpBar();

    }


    //if the player levels up twice on the same frame leveling up breaks, which should never happen normally
    public void GainXP(float xp) {
        XPGained += xp;

        if (XPGained >= EXPNeededPerLevel[Level]) {

            Level++;
            ChooseUpgrade();


        }

        PlayerStuffTracker.XPGained = XPGained;
        PlayerStuffTracker.Level = Level;

        UpdateXpBar();
    }

    public virtual void ChooseUpgrade() { 
    
        UpgradePickerMenu.SetActive(true);


    }

    public void UpdateXpBar()
    {

        if (Level != 0)
        {
            XPBar.fillAmount = (XPGained - EXPNeededPerLevel[Level - 1]) / (EXPNeededPerLevel[Level] - EXPNeededPerLevel[Level - 1]);
        }

        else {

            XPBar.fillAmount = (XPGained / EXPNeededPerLevel[Level] );

        }

    }


}
