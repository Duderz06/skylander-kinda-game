using UnityEngine;

public class SpilledChip : MonoBehaviour
{

    public float CritChanceAdded = 0.3f;

    private GameObject Parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        Parent = transform.parent.gameObject;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            AttacksChar6 AC6 = FindAnyObjectByType<AttacksChar6>();

            AC6.AddedCritChanceFromSecond += CritChanceAdded;

            Destroy(Parent);

        }


    }


}
