using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevelLoader : MonoBehaviour
{

    public string SceneName = "Title Screen";

    public void GoToNewScene() {


        SceneManager.LoadScene(SceneName);


    }

}
