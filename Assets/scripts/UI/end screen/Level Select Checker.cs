using UnityEngine;

public class LevelSelectChecker : MonoBehaviour
{

    private void OnEnable()
    {

        if (PlayerStuffTracker.LevelSelect && PlayerStuffTracker.LevelUpSelect > 0)
        {




        }
        else { 
        
            Destroy(gameObject);
        
        }

    }


}
