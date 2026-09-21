using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankHandler : MonoBehaviour
{

    public GameObject ResultsScreen;

    private ThingyTracker TT;

    public RawImage RankImage;
    public List<Texture2D> RankImages = new List<Texture2D> ();

    public float Points = 0f;
    public List<float> PointsForRank = new List<float> ();

    public float LossForDamage = 10f;
    public float TimeLeftPoints = 100f;
    public float EnemyPointsMax = 10000f;



    public float TimeForStageSeconds = 300f;

    public TextMeshProUGUI EnemiesKilledText;
    public TextMeshProUGUI MaxEnemiesText;
    public TextMeshProUGUI TimeTakenText;
    public TextMeshProUGUI DamageTakenText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        TT = FindAnyObjectByType<ThingyTracker>();

        ResultsScreen.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CalculateScore() { 
    
        EnemiesKilledText.text = TT.EnemiesKilled+"";
        MaxEnemiesText.text = TT.EnemiesInLevel + "";

        DamageTakenText.text = TT.DamageTaken+"";

       

        int Minutes = 0;
        float Seconds = TT.TimeTaken;

        while (Seconds>=60) { 
        

            Seconds -= 60;
            Minutes++;
        
        }

        string Timer = null;
        if (Seconds <= 9)
        {

            Timer = Minutes + ": 0" + Seconds;

        }

        else
        {
            Timer = Minutes + ":" + Seconds;
        }


        TimeTakenText.text = Timer;

        Points -= LossForDamage*TT.DamageTaken;

        Points += (TT.EnemiesKilled / TT.EnemiesInLevel) * EnemyPointsMax;

        Points += (TimeForStageSeconds - TT.TimeTaken) * TimeLeftPoints;


        if (Points >= PointsForRank[1])
        {

            if (Points >= PointsForRank[2])
            {

                if (Points >= PointsForRank[3])
                {

                    if (Points >= PointsForRank[4])
                    {

                        
                        RankImage.texture = RankImages[4];
                        

                    }

                    else
                    {

                        RankImage.texture = RankImages[3];
                    }

                }

                else
                {

                    RankImage.texture = RankImages[2];
                }

            }

            else
            {

                RankImage.texture = RankImages[1];
            }

        }

        else {

            RankImage.texture = RankImages[0];
        }
    
    }




    private void OnEnable()
    {
        
        CalculateScore();

    }




}
