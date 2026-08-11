using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerControls Input;

    public float MoveSpeed = 5f;
    public float Acceleration = 1f;
    public float RotateSpeed = 25f;
    private Rigidbody RB;
    private Transform Cam;

    private Vector3 Movement;

    public bool CanMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        RB = GetComponent<Rigidbody>();
        Cam = Camera.main.transform;


    }


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

    // Update is called once per frame
    void Update()
    {

        Vector3 DirForward = Cam.forward;
        Vector3 DirRight = Cam.right;

        DirForward.y = 0;

        DirRight.y = 0;


        DirForward.Normalize();
        DirRight.Normalize();


        Vector2 MoveInput = Input.gameplay.movement.ReadValue<Vector2>();


        if (CanMove)
        {
            Movement = DirForward * MoveInput.y + DirRight * MoveInput.x;

        }

        else
        {
            Movement = Vector3.zero;

        }

        Movement.Normalize();


    }

    void FixedUpdate()
    {
        Vector3 TargetVel = Movement * MoveSpeed;

        TargetVel.y = RB.linearVelocity.y;


        RB.linearVelocity = Vector3.MoveTowards( RB.linearVelocity, TargetVel, Acceleration * Time.fixedDeltaTime);


        Vector3 FlatVelocity = new Vector3(RB.linearVelocity.x, 0, RB.linearVelocity.z);


        if (Movement.sqrMagnitude > 0.01f)
        {
            Quaternion TargetRotation = Quaternion.LookRotation(Movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation,RotateSpeed * Time.fixedDeltaTime);



        }



    }

}
