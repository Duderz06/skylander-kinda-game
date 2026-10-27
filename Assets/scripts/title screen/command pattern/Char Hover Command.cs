using System.Windows.Input;
using TMPro;
using UnityEngine;

public class CharHoverCommand : ButtonCommand
{
   
    private TextMeshPro NameText;
    private TextMeshPro DescriptionText;

    private string Name;
    private string Description;


    public CharHoverCommand(TextMeshPro NameText2, TextMeshPro DescriptionText2, string Name2, string Description2)
    {
        NameText = NameText2;
        DescriptionText = DescriptionText2;

        Name = Name2;
        Description = Description2;
    }


    public void Execute()
    {
        NameText.text = Name;

        DescriptionText.text = Description;


    }


}



