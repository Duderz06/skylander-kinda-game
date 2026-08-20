using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSign : MonoBehaviour
{

    public List<Material> Frames = new List<Material>();

    public float TimeBetweenFrames = 0.5f;

    private MeshRenderer MR;

    private int CurrentFrame = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        MR = GetComponent<MeshRenderer>();

        StartCoroutine(AnimateSign());

    }



    public IEnumerator AnimateSign()
    {

        while (true) { 
        
        
            yield return new WaitForSeconds(TimeBetweenFrames);

            CurrentFrame++;

            if (CurrentFrame >= Frames.Count) {

                CurrentFrame = 0;
            
            }


            MR.material = Frames[CurrentFrame];


        
        
            yield return null;
        
        }



    }


   
}
