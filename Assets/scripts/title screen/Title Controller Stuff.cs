using NUnit.Framework;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class TitleControllerStuff : MonoBehaviour
{

    private PlayerControls Input;
    private TitleCamera TC;

    private AchievementSwapper AS;


    public int SelectedObj = 0;

    public List <TitleButtonClick> BackButtons = new List<TitleButtonClick> (); 





    void Awake()
    {
        Input = new PlayerControls();

    }
    void OnEnable()
    {

        Input.Enable();

    }

    void OnDisable()
    {

        Input.Disable();

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TC = FindAnyObjectByType<TitleCamera>();

        AS = FindAnyObjectByType<AchievementSwapper>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.TitleScreen.moveup.WasPressedThisFrame() )
        {

            MoveUp();

        }



        if (Input.TitleScreen.movedown.WasPressedThisFrame())
        {

            MoveDown();

        }




        if (Input.TitleScreen.moveleft.WasPressedThisFrame())
        {

            MoveLeft();

        }



        if (Input.TitleScreen.moveright.WasPressedThisFrame())
        {

            MoveRight();

        }


        if (Input.TitleScreen.back.WasPressedThisFrame())
        {

           Back();

        }

        if (Input.TitleScreen.select.WasPressedThisFrame())
        {

            Select();

        }


    }

    public void MoveUp() {

        if (TC.CurrentSpot == 0)
        {

            if (SelectedObj == 0)
            {

                SelectedObj = 3;

            }

            else
            {

                SelectedObj--;

            }

        }

        else if (TC.CurrentSpot == 4) {

            if (SelectedObj == 1 || SelectedObj == 3)
            {

                SelectedObj--;

            }

            else if (SelectedObj == 5)
            {

                SelectedObj = 1;

            }

            else if (SelectedObj == 6) {


                SelectedObj = 3;
            
            }

        
        }
    

    
    
    }


    public void MoveDown()
    {

        if (TC.CurrentSpot == 0)
        {

            if (SelectedObj == 3)
            {

                SelectedObj = 0;


            }

            else { 
            
                SelectedObj++;
            
            }


        
        }


        if (TC.CurrentSpot == 4) {

            if (SelectedObj == 0 || SelectedObj == 2)
            {

                SelectedObj++;


            }

            else if (SelectedObj == 4)
            {

                SelectedObj = 3;


            }


            else if (SelectedObj == 1)
            {

                SelectedObj = 5;

            }

            else if (SelectedObj == 3) { 
            
                SelectedObj = 6;
            
            }



        }



    }



    public void MoveLeft()
    {

        if (TC.CurrentSpot == 1)
        {

            if (SelectedObj == 0)
            {

                SelectedObj = 1;

            }

            else if (SelectedObj == 1)
            {

                SelectedObj = 0;

            }

        }

        else if (TC.CurrentSpot == 4)
        {


            if (SelectedObj <= 4 && SelectedObj > 0)
            {

                SelectedObj--;

            }
            else if (SelectedObj == 0)
            {

                SelectedObj = 4;

            }

            else if (SelectedObj == 5)
            {

                SelectedObj = 6;

            }


            else if (SelectedObj == 6)
            {

                SelectedObj = 5;

            }
        }




        else if (TC.CurrentSpot == 2) {

            if (SelectedObj == 0)
            {

                SelectedObj = 6;

            }

            else {

                SelectedObj--;
            
            }
        
        
        }


        else if (TC.CurrentSpot == 5)
        {


            AS.MoveLeft();


        }

    }


    public void MoveRight()
    {
        if (TC.CurrentSpot == 1)
        {

            if (SelectedObj == 0)
            {

                SelectedObj = 1;

            }

            else if (SelectedObj == 1)
            {

                SelectedObj = 0;

            }

        }


        else if (TC.CurrentSpot == 4)
        {


            if (SelectedObj <= 3 && SelectedObj >= 0)
            {

                SelectedObj++;

            }
            else if (SelectedObj == 4)
            {

                SelectedObj = 0;

            }

            else if (SelectedObj == 5)
            {

                SelectedObj = 6;

            }


            else if (SelectedObj == 6)
            {

                SelectedObj = 5;

            }
        }



        else if (TC.CurrentSpot == 2)
        {

            if (SelectedObj == 6)
            {

                SelectedObj = 0;


            }

            else
            {

                SelectedObj++;

            }


        }


        else if (TC.CurrentSpot == 5) { 
        

            AS.MoveRight();
        
        
        }


    }


    public void Select() { 
    
    
    
    }

    public void Back() {

        BackButtons[TC.CurrentSpot].DoThing();
    
    
    }

}
