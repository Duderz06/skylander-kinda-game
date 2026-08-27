using UnityEngine;

public class LevelSelectLevelUp : MonoBehaviour
{
    private LevelSelectLevelUpSelector LSLUS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LSLUS = FindAnyObjectByType<LevelSelectLevelUpSelector>();


    }


    public void OnMouseDown()
    {

        LSLUS.LevelUp();

    }





}
