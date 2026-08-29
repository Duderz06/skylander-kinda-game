using TMPro;
using UnityEngine;

public class CharSelectButton : MonoBehaviour
{

    public int CharNum = 0;

    public TextMeshPro NameText;
    public TextMeshPro DescriptionText;
    public string Name;
    public string Description;

    private CharSelectShowSelected CSSS;

    void Start()
    {
        CSSS = FindAnyObjectByType <CharSelectShowSelected>();

        
    }
    public void OnMouseDown()
    {

        DoSelected();
        
    }

    public void OnMouseOver()
    {

        DoHover();

    }

    public void DoSelected() {

        PlayerStuffTracker.WhichCharacter = CharNum;
        CSSS.UpdateSpot(CharNum);


    }

    public void DoHover()
    {

        NameText.text = Name;
        DescriptionText.text = Description;


    }


}
