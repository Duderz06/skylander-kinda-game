using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharSelectShowSelected : MonoBehaviour
{



    public List<Transform> Spots = new List<Transform> ();

    public void UpdateSpot(int spot)
    {



        transform.position = Spots[spot].position;
        transform.rotation = Spots[spot].rotation;

    }

}
