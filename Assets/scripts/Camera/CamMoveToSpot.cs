using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CamMoveToSpot : MonoBehaviour
{

    private PlayerControls Input;


    public float BaseYChange = 6f;
    public float BaseZChange = -11.5f;
    public Vector3 BaseRotation;
    public float MoveSpeed = 5f;

    public float TopDownYChange = 10f;
    public float TopDownZChange = 0f;
    public bool TopDown = false;
    public Vector3 TopDownRotation;

    private GameObject Player;


    void Awake()
    {
        Input = new PlayerControls();

    }

    void OnEnable()
    {

        Input.Enable();

    }

    void OnDisable()
    {

        Input.Disable();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.gameplay.CamChange.WasPressedThisFrame())
        {

            TopDown = !TopDown;

        }


        Vector3 CamSpot = Player.transform.position;
        Quaternion CamRotation = Quaternion.identity;

        if (!TopDown)
        {

            CamSpot.y += BaseYChange;
            CamSpot.z += BaseZChange;

            CamRotation = Quaternion.Euler(BaseRotation);
        }

        else {

            CamSpot.y += TopDownYChange;
            CamSpot.z += TopDownZChange;
            CamRotation = Quaternion.Euler(TopDownRotation);

        }


        transform.position = Vector3.Lerp(transform.position, CamSpot, MoveSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, MoveSpeed);




    }



}
