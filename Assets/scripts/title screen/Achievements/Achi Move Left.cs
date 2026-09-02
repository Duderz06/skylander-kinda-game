using UnityEngine;

public class AchiMoveLeft : MonoBehaviour
{

    private AchievementSwapper AS;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AS = FindAnyObjectByType<AchievementSwapper>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseDown()
    {
        AS.MoveLeft();

    }


}
