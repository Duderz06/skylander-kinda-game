using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePickerHandler : MonoBehaviour
{

    private PlayerControls Input;

    public UpgradeHandler UH;

    public List<Button> Buttons = new List<Button>();
    public List<Color> PressableColours = new List<Color>();
    public List<Color> UnPressableColours = new List<Color>();

    public List<bool> CanPressButton = new List<bool>();

    public CharacterImagesandDesc CID;
    public Image ShowcaseImage;
    public TextMeshProUGUI UpgradeDesc;
    public TextMeshProUGUI UpgradeName;


    public Image ButtonSelectedImage;
    public List<RectTransform> ButtonSpots = new List<RectTransform>();

    public int HoveredOver = 0;
    //min 0 max 13

    private bool BufferedUp = false;
    private bool BufferedLeft = false;
    private bool BufferedDown = false;
    private bool BufferedRight = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UH = FindAnyObjectByType<UpgradeHandler>();
        CID = FindAnyObjectByType<CharacterImagesandDesc>();
        PickedUpgrade();
    }

    void Awake()
    {
        Input = new PlayerControls();

    }





    void Update()
    {

        if (Input.upgradeselection.cursorup.WasPressedThisFrame() && !BufferedDown && !BufferedLeft && !BufferedRight)
        {

            BufferedUp = true;

            MoveCursor();
        }

        if (Input.upgradeselection.cursordown.WasPressedThisFrame() && !BufferedUp && !BufferedLeft && !BufferedRight)
        {


            BufferedDown = true;

            MoveCursor();

        }

        if (Input.upgradeselection.cursorleft.WasPressedThisFrame() && !BufferedDown && !BufferedUp && !BufferedRight)
        {

            BufferedLeft = true;


            MoveCursor();

        }

        if (Input.upgradeselection.cursorright.WasPressedThisFrame() && !BufferedDown && !BufferedLeft && !BufferedUp)
        {

            BufferedRight = true;


            MoveCursor();

        }



        if (Input.upgradeselection.selectupgrade.WasPressedThisFrame())
        {

            if (HoveredOver == 1)
            {

                UnlockSecondary();


            }

            else if (HoveredOver == 2) { 
            
                UnlockPassive();
            
            }

            else if (HoveredOver == 3)
            {

                UnlockMainUpgrade1();

            }

            else if (HoveredOver == 4)
            {

                UnlockSecondaryUpgrade1();

            }


            else if (HoveredOver == 5)
            {

                UnlockMainUpgrade2();

            }

            else if (HoveredOver == 6)
            {

                UnlockSecondaryUpgrade2();

            }

            else if (HoveredOver == 7)
            {

                UnlockMainUpgrade3();

            }

            else if (HoveredOver == 8)
            {

                UnlockSecondaryUpgrade3();

            }

            else if (HoveredOver == 9)
            {

                UnlockMainUpgrade4();

            }

            else if (HoveredOver == 10)
            {

                UnlockSecondaryUpgrade4();

            }

            else if (HoveredOver == 11)
            {

                UnlockFinalUpgrade1();

            }

            else if (HoveredOver == 12)
            {

                UnlockFinalUpgrade2();

            }

            else if (HoveredOver == 13)
            {

                UnlockUltimateUpgrade();

            }

        }


    }


    public void MoveCursor() {

        if (BufferedUp && HoveredOver >= 2 && HoveredOver <= 10)
        {

            HoveredOver--;

        }

        else if (BufferedDown && HoveredOver >= 1 && HoveredOver <= 9)
        {


            HoveredOver++;

        }

        else if (BufferedRight) {

            if (HoveredOver == 0 || HoveredOver == 10 || HoveredOver == 11 || HoveredOver == 12) {

                HoveredOver++;
            
            
            }
            else
            {
                HoveredOver += 2;
            }


        }

        else if (BufferedLeft)
        {

            if (HoveredOver == 0 || HoveredOver == 11 || HoveredOver == 12)
            {

                HoveredOver--;


            }
            else
            {
                HoveredOver -= 2;
            }


        }


        if (HoveredOver < 0) {

            HoveredOver = 0;
        
        }

        if (HoveredOver > 13) { 
        
            HoveredOver = 13;
        }

        BufferedUp = false;
        BufferedDown = false;
        BufferedLeft = false;
        BufferedRight = false;

        ImageAndDescShower(HoveredOver);

        ButtonSelectedImage.rectTransform.position = ButtonSpots[HoveredOver].position;

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
        Input.Enable();
        ImageAndDescShower(HoveredOver);

    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        Input.Disable();

    }

   

}

