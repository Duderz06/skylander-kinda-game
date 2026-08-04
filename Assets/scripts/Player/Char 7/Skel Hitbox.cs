using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SkelHitbox : MonoBehaviour
{

    public float Damage = 5f;

    public float LifeTime = 7f;


    private GameObject Parent;

    private UpgradeHandler Upgrades;

    public GameObject LifeGhost;

    public bool SpawnBones = false;

    public GameObject Bones;
    public Transform BoneSpawnSpot;
    public float AmountOfBones = 2;
    public float BoneForceMin = 3f;
    public float BoneForceMax = 7f;
    public float MaxBoneAngle = 45f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        StartCoroutine(DestoryAfterTime());

        Parent = transform.parent.gameObject;

        Upgrades = FindAnyObjectByType<UpgradeHandler>();



    }

    // Update is called once per frame
    void Update()
    {
        


    }


    public IEnumerator DestoryAfterTime()
    {
        yield return new WaitForSeconds(LifeTime);

        Destroy(Parent);



    }

    public virtual void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy")) {


            EnemyParent EP = other.GetComponent<EnemyParent>();

            EP.TakeDamage(Damage);

            if (Upgrades.MainUpgrade2) {

               // Instantiate(LifeGhost, transform.position, transform.rotation);
            
            }


            if (Upgrades.MainUpgrade3 && SpawnBones) {

                for (int i = 0; i < AmountOfBones; i++) {

                    GameObject spawnedbone = Instantiate(Bones, BoneSpawnSpot.position, BoneSpawnSpot.rotation);


                    Rigidbody RB = spawnedbone.GetComponent<Rigidbody>();


                    //i stole this from online i have no clue how it works
                    float Angle = Mathf.Acos(Random.Range(Mathf.Cos(MaxBoneAngle * Mathf.Deg2Rad), 1f));
                    float azimuth = Random.Range(0f, Mathf.PI * 2f);

                    Vector3 direction = new Vector3(Mathf.Sin(Angle) * Mathf.Cos(azimuth), Mathf.Cos(Angle), Mathf.Sin(Angle) * Mathf.Sin(azimuth));

                    float RandForce = Random.Range(BoneForceMin, BoneForceMax);

                    RB.AddForce(direction * RandForce, ForceMode.Impulse);

                }
            
            
            }
           


            Destroy(Parent);
            
            

        }




    }

}
