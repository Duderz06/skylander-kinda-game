using UnityEngine;

public class CharSelectButton : MonoBehaviour
{

    public int CharNum = 0;


    public void OnMouseDown()
    {

        PlayerStuffTracker.WhichCharacter = CharNum;

    }
}
