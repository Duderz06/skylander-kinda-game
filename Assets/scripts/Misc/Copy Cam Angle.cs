using UnityEngine;

public class CopyCamAngle : MonoBehaviour
{


    private Transform camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.rotation = camera.rotation;

    }

}
