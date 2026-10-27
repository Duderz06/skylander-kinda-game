using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToSceneButton : MonoBehaviour
{

    public string SceneName;

    private ButtonCommand ToSceneCommand;

    void Start()
    {


        ToSceneCommand = new ToSceneCommand(SceneName);



    }


    public void OnMouseDown()
    {

        ToSceneCommand.Execute();


    }

}
