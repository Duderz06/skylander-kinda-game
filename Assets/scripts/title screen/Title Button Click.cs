using UnityEngine;

public class TitleButtonClick : MonoBehaviour
{

    private TitleCamera TC;
    private TitleControllerStuff TCS;

    public int CamSpot = 0;
    public int TCSStartSpot = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TC = FindAnyObjectByType<TitleCamera>();
        TCS = FindAnyObjectByType<TitleControllerStuff>();


    }


    public void OnMouseDown()
    {
        DoThing();


    }

    public void DoThing() {
        TC.CurrentSpot = CamSpot;
        TCS.SelectedObj = TCSStartSpot;

    }

}
