using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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




    // Update is called once per frame
    void Update()
    {

        Movement = Vector3.zero;

        Vector3 DirF = Cam.forward;
        Vector3 DirR = Cam.right;

        DirF.y = 0;
        DirR.y = 0;

        DirF.Normalize();
        DirR.Normalize();

        if (CanMove)
        {

            if (Input.GetKey(KeyCode.W))
            {

                Movement += DirF;
            }



            if (Input.GetKey(KeyCode.S))
            {

                Movement -= DirF;

            }


            if (Input.GetKey(KeyCode.D))
            {

                Movement += DirR;

            }


            if (Input.GetKey(KeyCode.A))
            {

                Movement -= DirR;

            }
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
