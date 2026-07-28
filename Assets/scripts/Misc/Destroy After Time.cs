using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float Time = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DieAfterTime());
    }

    public IEnumerator DieAfterTime() { 
    
        yield return new WaitForSeconds(Time);

        Destroy(gameObject);
    
    
    }
}
