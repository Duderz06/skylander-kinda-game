
using System.Windows.Input;
using UnityEngine;

public class TitleButtonCommand : ButtonCommand
{
    private TitleCamera TC;
    private TitleControllerStuff TCS;

    private int CamSpot;
    private int TCSStartSpot;

    public TitleButtonCommand(TitleCamera TC2, TitleControllerStuff TCS2, int CamSpot2, int TCSStartSpot2)
    {
        TC = TC2;
        TCS = TCS2;

        CamSpot = CamSpot2;
        TCSStartSpot = TCSStartSpot2;
    }


    public void Execute()
    {


        TC.CurrentSpot = CamSpot;

        TCS.SelectedObj = TCSStartSpot;

    }



}
