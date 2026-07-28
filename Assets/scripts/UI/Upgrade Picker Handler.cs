using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePickerHandler : MonoBehaviour
{

    public UpgradeHandler UH;

    public List<Button> Buttons = new List<Button>();
    public List<Color> PressableColours = new List<Color>();
    public List<Color> UnPressableColours = new List<Color>();

    public List<bool> CanPressButton = new List<bool>();

    public CharacterImagesandDesc CID;
    public Image ShowcaseImage;
    public TextMeshProUGUI UpgradeDesc;
    public TextMeshProUGUI UpgradeName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UH = FindAnyObjectByType<UpgradeHandler>();
        CID = FindAnyObjectByType<CharacterImagesandDesc>();
        PickedUpgrade();
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void UpdateColours() {


        int i = 0;

        foreach (var button in Buttons)
        {


            if (CanPressButton[i])
            {
                button.image.color = PressableColours[i];


            }


            else
            {
                button.image.color = UnPressableColours[i];


            }


            i++;


        }


    }

    public void PickedUpgrade() {

        if (UH.MainMove) { 
        
            CanPressButton[0] = false;
            CanPressButton[1] = true;
            CanPressButton[2] = true;


            if (UH.SecondaryMove) {

                CanPressButton[1] = false;


            }

            if (UH.Passive)
            {

                CanPressButton[2] = false;


            }

            if (UH.SecondaryMove && UH.Passive) {

                CanPressButton[3] = true;
                CanPressButton[4] = true;


                if (UH.MainUpgrade1) {

                    CanPressButton[3] = false;
                    CanPressButton[4] = false;
                    CanPressButton[5] = true;


                }


                if (UH.SecondaryUpgrade1)
                {

                    CanPressButton[3] = false;
                    CanPressButton[4] = false;
                    CanPressButton[6] = true;


                }



                if (UH.MainUpgrade2 || UH.SecondaryUpgrade2) {

                    CanPressButton[5] = false;
                    CanPressButton[6] = false;


                    CanPressButton[7] = true;
                    CanPressButton[8] = true;



                    if (UH.MainUpgrade3)
                    {

                        CanPressButton[7] = false;
                        CanPressButton[8] = false;
                        CanPressButton[9] = true;


                    }


                    if (UH.SecondaryUpgrade3)
                    {

                        CanPressButton[7] = false;
                        CanPressButton[8] = false;
                        CanPressButton[10] = true;


                    }


                    if (UH.MainUpgrade4 || UH.SecondaryUpgrade4)
                    {

                        CanPressButton[9] = false;
                        CanPressButton[10] = false;


                        CanPressButton[11] = true;

                        if (UH.FinalUpgrade1) {

                            CanPressButton[11] = false;
                            CanPressButton[12] = true;

                            if (UH.FinalUpgrade2)
                            {

                                CanPressButton[12] = false;
                                CanPressButton[13] = true;



                            }

                        }

                    }

                }

            }


        }



        UpdateColours();
        
        UH.UpgradePickerMenu.SetActive(false);
    
    }




    public void ImageAndDescShower(int WhichOne) {

        if (CID.ShowcaseImages[WhichOne] != null) {

            ShowcaseImage.sprite = CID.ShowcaseImages[WhichOne];


        }

        if (CID.UpgradeDesc[WhichOne] != null)
        {

            UpgradeDesc.text = CID.UpgradeDesc[WhichOne];


        }

        if (CID.UpgradeNames[WhichOne] != null)
        {

            UpgradeName.text = CID.UpgradeNames[WhichOne];


        }




    }



    public void UnlockSecondary() {

        if (CanPressButton[1] && !UH.SecondaryMove) {

            UH.SecondaryMove = true;

            PickedUpgrade();
        }


    }

    public void UnlockPassive()
    {

        if (CanPressButton[2] && !UH.Passive)
        {

            UH.Passive = true;

            PickedUpgrade();
        }


    }


    public void UnlockMainUpgrade1()
    {

        if (CanPressButton[3] && !UH.MainUpgrade1)
        {

            UH.MainUpgrade1 = true;

            PickedUpgrade();
        }


    }

    public void UnlockSecondaryUpgrade1()
    {

        if (CanPressButton[4] && !UH.SecondaryUpgrade1)
        {

            UH.SecondaryUpgrade1 = true;

            PickedUpgrade();
        }


    }



    public void UnlockMainUpgrade2()
    {

        if (CanPressButton[5] && !UH.MainUpgrade2)
        {

            UH.MainUpgrade2 = true;

            PickedUpgrade();
        }


    }

    public void UnlockSecondaryUpgrade2()
    {

        if (CanPressButton[6] && !UH.SecondaryUpgrade2)
        {

            UH.SecondaryUpgrade2 = true;

            PickedUpgrade();
        }


    }


    public void UnlockMainUpgrade3()
    {

        if (CanPressButton[7] && !UH.MainUpgrade3)
        {

            UH.MainUpgrade3 = true;

            PickedUpgrade();
        }


    }

    public void UnlockSecondaryUpgrade3()
    {

        if (CanPressButton[8] && !UH.SecondaryUpgrade3)
        {

            UH.SecondaryUpgrade3 = true;

            PickedUpgrade();
        }


    }





    public void UnlockMainUpgrade4()
    {

        if (CanPressButton[9] && !UH.MainUpgrade4)
        {

            UH.MainUpgrade4 = true;

            PickedUpgrade();
        }


    }

    public void UnlockSecondaryUpgrade4()
    {

        if (CanPressButton[10] && !UH.SecondaryUpgrade4)
        {

            UH.SecondaryUpgrade4 = true;

            PickedUpgrade();
        }


    }



    public void UnlockFinalUpgrade1()
    {

        if (CanPressButton[11] && !UH.FinalUpgrade1)
        {

            UH.FinalUpgrade1 = true;

            PickedUpgrade();
        }


    }




    public void UnlockFinalUpgrade2()
    {

        if (CanPressButton[12] && !UH.FinalUpgrade2)
        {

            UH.FinalUpgrade2 = true;

            PickedUpgrade();
        }


    }


    public void UnlockUltimateUpgrade()
    {
        if (CanPressButton[13] && !UH.UltimateUpgrade)
        {

            UH.UltimateUpgrade = true;

            PickedUpgrade();
        }


    }





    private void OnEnable()
    {
        Time.timeScale = 0f;

    }

    private void OnDisable()
    {
        Time.timeScale = 1f;

    }



}

