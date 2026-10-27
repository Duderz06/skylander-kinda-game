using System.Windows.Input;
using UnityEngine;

public class TitleButtonClick : MonoBehaviour
{

    private TitleCamera TC;
    private TitleControllerStuff TCS;

    public int CamSpot = 0;
    public int TCSStartSpot = 0;

    private ButtonCommand Command;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TC = FindAnyObjectByType<TitleCamera>();
        TCS = FindAnyObjectByType<TitleControllerStuff>();


        Command = new TitleButtonCommand(TC, TCS, CamSpot, TCSStartSpot);


    }


    public void OnMouseDown()
    {
        DoThing();


    }

    public void DoThing() {
        Command.Execute();

    }

}
