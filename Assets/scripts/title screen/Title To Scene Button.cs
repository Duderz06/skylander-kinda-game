using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToSceneButton : MonoBehaviour
{

    public string SceneName;

    public void OnMouseDown()
    {

        SceneManager.LoadScene(SceneName);


    }

}
