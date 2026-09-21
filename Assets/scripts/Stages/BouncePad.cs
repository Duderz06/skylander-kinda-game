using UnityEngine;

public class BouncePad : MonoBehaviour
{


    public float BouncePower = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        
        Rigidbody RB = other.GetComponent<Rigidbody>();

        if (RB != null) { 
        
            Vector3 Vel = RB.linearVelocity;

            Vel.y = BouncePower;

            RB.linearVelocity = Vel;
        
        
        
        }

    }






}
