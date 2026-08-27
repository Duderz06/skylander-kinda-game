using UnityEngine;

public class LevelSelectLevelDown : MonoBehaviour
{
    private LevelSelectLevelUpSelector LSLUS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LSLUS = FindAnyObjectByType<LevelSelectLevelUpSelector>();


    }


    public void OnMouseDown()
    {

        LSLUS.LevelDown();

    }





}
