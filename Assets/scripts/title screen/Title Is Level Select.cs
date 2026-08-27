using UnityEngine;

public class TitleIsLevelSelect : MonoBehaviour
{

    public bool MakeLevelSelect = true;

    public void OnMouseDown()
    {


        PlayerStuffTracker.LevelSelect=MakeLevelSelect;


    }


}
