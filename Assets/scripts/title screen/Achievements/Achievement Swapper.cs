using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSwapper : MonoBehaviour
{

    private AchievementPlacer AP;

    private Vector3 BaseSpot;


    public int MinSpot = 0;
    public int MaxSpot = 10;

    public float Speed = 5f;

    private Coroutine Thingy;

    public int Spot = 0;

    public TextMeshPro AchiName;
    public TextMeshPro AchiDesc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AP = GetComponent<AchievementPlacer>();

        BaseSpot = transform.localPosition;

        MaxSpot = AP.Acheivements.Count;
        UpdateText();

    }

    // Update is called once per frame
    void Update()
    {
        




    }


    //spamming left or right can get them out of sync
    public void MoveRight() {

        if (Spot != MaxSpot-1)
        {
            Vector3 spot = transform.localPosition;

            spot.x -= AP.XChange;

            UpdateSpot(spot);
            Spot++;
        }


    } 
    
    
    public void MoveLeft() {

        if (Spot != MinSpot)
        {

            Vector3 spot = transform.localPosition;

            spot.x += AP.XChange;

            UpdateSpot(spot);
            Spot--;
        }
    }

    public void UpdateSpot(Vector3 spot)
    {

        if (Thingy == null) {

            Thingy = StartCoroutine(GoToSpot(spot));
        }


        


    }

    public IEnumerator GoToSpot(Vector3 spot) {

        while (Vector3.Distance(transform.localPosition, spot) > 0) {

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, spot, Speed);
        

            yield return null;
        }

        transform.localPosition = spot;
        UpdateText();


        Thingy = null;

    }

    public void UpdateText() {


        AchiNameDesc AchiNameDesc = AP.Acheivements[Spot].GetComponent<AchiNameDesc>();

        AchiName.text = AchiNameDesc.Name;
        AchiDesc.text = AchiNameDesc.Description;
    }

}
