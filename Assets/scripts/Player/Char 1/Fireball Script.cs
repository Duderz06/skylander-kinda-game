using UnityEngine;

public class FireballScript : MonoBehaviour
{

    private Rigidbody rb;
    public float ForwardSpeed = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * ForwardSpeed;

    }

    



}