using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EndScreenPlugin : MonoBehaviour
{

    public int WhichLevel = 0;
    public TextMeshProUGUI LevelName;

    public void UpdateLevelName()
    {

        if (WhichLevel == 0)
        {
            LevelName.text = MyPlugin.Level0Name;
        }

        else if (WhichLevel == 1)
        {
            LevelName.text = MyPlugin.Level1Name;
        }


        else if (WhichLevel == 2)
        {
            LevelName.text = MyPlugin.Level2Name;
        }



        else if (WhichLevel == 3)
        {
            LevelName.text = MyPlugin.Level3Name;
        }



        else if (WhichLevel == 4)
        {
            LevelName.text = MyPlugin.Level4Name;
        }


    }

}
