using UnityEngine;

public class TitleButtonClick : MonoBehaviour
{

    private TitleCamera TC;

    public int CamSpot = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TC = FindAnyObjectByType<TitleCamera>();


    }


    public void OnMouseDown()
    {
        
        TC.CurrentSpot=CamSpot;

    }

}
