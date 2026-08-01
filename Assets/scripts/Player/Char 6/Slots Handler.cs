using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsHandler : MonoBehaviour
{

    public int AmountOfOptions = 5;

    public int ChosenOption;

    public List<float> ChanceAdd = new List<float>();
    public List<Material> Mats = new List<Material>();

    public List<GameObject> Coinsplostion = new List<GameObject>();

    public MeshRenderer Slot1Rend;
    public MeshRenderer Slot2Rend;
    public MeshRenderer Slot3Rend;

    public float SpinTime = 0.3f;
    public float WaitBetweenTime = 0.2f;

    private UpgradeHandler Upgrades;
    

    void Start()
    {

        Upgrades = FindAnyObjectByType<UpgradeHandler>();


    }

    public void StartSpinning(float option) {

        ChosenOption = ((int)option);

        StartCoroutine(DoGambling());
    
    }


    public IEnumerator DoGambling()
    {

        Debug.Log(ChosenOption);

        yield return new WaitForSeconds(SpinTime);

        Slot1Rend.material = Mats[ChosenOption];

        yield return new WaitForSeconds(WaitBetweenTime);

        Slot2Rend.material = Mats[ChosenOption];

        yield return new WaitForSeconds(WaitBetweenTime);

        Slot3Rend.material = Mats[ChosenOption];

        yield return new WaitForSeconds(WaitBetweenTime);


        AttacksChar6 AC6 = FindAnyObjectByType<AttacksChar6>();

        AC6.AddedCritChanceFromSecond += ChanceAdd[ChosenOption];

        if (Upgrades.SecondaryUpgrade1) {

            Instantiate(Coinsplostion[ChosenOption], transform.position, transform.rotation);
        
        }

        Destroy(gameObject);

    }



}
