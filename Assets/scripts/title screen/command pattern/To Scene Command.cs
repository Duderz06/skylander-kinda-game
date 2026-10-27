using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSceneCommand : ButtonCommand
{
    private string SceneName;


    public ToSceneCommand(string SceneName2)
    {
        SceneName = SceneName2;
    }




    public void Execute()
    {

        SceneManager.LoadScene(SceneName);


    }

}
