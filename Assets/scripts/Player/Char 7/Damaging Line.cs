using System.Collections;
using UnityEngine;

public class DamagingLine : MonoBehaviour
{

    private UpgradeHandler Upgrades;
    private GameObject Player;
    private AttacksChar7 AC7;

    public Transform Turret;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Upgrades = FindAnyObjectByType<UpgradeHandler>();
        Player = Upgrades.gameObject;
        AC7 = Player.GetComponent<AttacksChar7>();

        StartCoroutine(MoveToSpot());
    }


    public IEnumerator MoveToSpot() {



        while (true) {



            Vector3 Midpoint;
            float Distance;
            Vector3 Scale;
            Vector3 Dir;


            Dir = Turret.position - Player.transform.position;
            Distance = Dir.magnitude;
            Dir.Normalize();




            Midpoint = (Turret.position + Player.transform.position)/2;

            transform.position = Midpoint;


            Scale = transform.localScale;

            Scale.z = Distance;
            //leaves some empty space between this object and the objects it should connect to
            //empty space grows the farther they are
            
            transform.localScale = Scale;


            transform.rotation = Quaternion.LookRotation(Dir);

            
            
            
            yield return null;
        }
    
    
    }


}
