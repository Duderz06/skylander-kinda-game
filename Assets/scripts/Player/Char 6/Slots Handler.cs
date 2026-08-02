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

    public GameObject Chip;
    public List<int> ChipsToSpawn = new List<int>();
    public float MaxChipAngle = 7f;
    public float MaxChipForce = 1f;
    public float MinChipForce = 3f;

    


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


        if (Upgrades.SecondaryUpgrade2)
        {
            for (int i = 0; i < ChipsToSpawn[ChosenOption]; i++)
            {


                GameObject chip = Instantiate(Chip, transform.position, Quaternion.identity);

                Rigidbody ChipRb = chip.GetComponent<Rigidbody>();

                float Angle = Mathf.Acos(Random.Range(Mathf.Cos(MaxChipAngle * Mathf.Deg2Rad), 1f));
                float azimuth = Random.Range(0f, Mathf.PI * 2f);

                Vector3 direction = new Vector3(Mathf.Sin(Angle) * Mathf.Cos(azimuth), Mathf.Cos(Angle), Mathf.Sin(Angle) * Mathf.Sin(azimuth));

                float RandForce = Random.Range(MinChipForce, MaxChipForce);

                ChipRb.AddForce(direction * RandForce, ForceMode.Impulse);

                yield return null;
            }


        }


        Destroy(gameObject);

    }



}
