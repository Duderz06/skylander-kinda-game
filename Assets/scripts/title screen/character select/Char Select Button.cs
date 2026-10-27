using System.Windows.Input;
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


    private ButtonCommand SelectCommand;
    private ButtonCommand HoverCommand;

    void Start()
    {
        CSSS = FindAnyObjectByType<CharSelectShowSelected>();


        SelectCommand = new CharSelectCommand(CSSS, CharNum);

        HoverCommand = new CharHoverCommand(NameText, DescriptionText, Name, Description);


    }


    public void OnMouseDown()
    {
        DoSelected();
    }

    public void OnMouseOver()
    {
        DoHover();
    }

    public void DoSelected()
    {
        SelectCommand.Execute();
    }

    public void DoHover()
    {
        HoverCommand.Execute();
    }


}

