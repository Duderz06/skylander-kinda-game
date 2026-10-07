using UnityEngine;

public class HandBossShockwaveGrow : MonoBehaviour
{


    public float GrowSpeed = 1f;

    private Vector3 Size = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Size = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {


        Size.x += GrowSpeed * Time.deltaTime;
        Size.z += GrowSpeed * Time.deltaTime;


        transform.localScale = Size;




    }


}
