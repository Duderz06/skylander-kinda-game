using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectLevelUpSelector : MonoBehaviour
{

    public int Level = 1;
    public TextMeshPro LevelText;

    private int LevelMin = 0;
    private int LevelMax = 9;

    

    public void LevelUp() {

        Level++;

        if (Level > LevelMax) { 
        
            Level = LevelMax;
        
        }

        UpdateNumber();
    }
    public void LevelDown()
    {

        Level--;

        if (Level < LevelMin)
        {

            Level = LevelMin;

        }

        UpdateNumber();
    }


    public void UpdateNumber() { 
        
        LevelText.text = Level.ToString();
        PlayerStuffTracker.LevelUpSelect = Level;

    }


}
