using UnityEngine;
using UnityEngine.UIElements;

public class AttackHandler : MonoBehaviour
{

    private bool BufferedMain = false;
    private bool BufferedSecondary = false;

    public bool CanAttack = true;
    public bool CanMain=true;
    public bool CanSecondary=true;

    private AttackParent AttackScript;
    private UpgradeHandler UH;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        AttackScript = GetComponent<AttackParent>();
        UH = GetComponent<UpgradeHandler>();

    }

    // Update is called once per frame
    void Update()
    {

        //figure out how to do cooldown stuff so they cant attack if they are already attacking
        if (Input.GetMouseButtonDown(0) & !BufferedSecondary && CanAttack && CanMain)
        {

            BufferedMain = true;

        }

        if (Input.GetMouseButtonDown(1) && !BufferedMain && UH.SecondaryMove && CanAttack && CanSecondary)
        {

            BufferedSecondary = true;

        }

    }



    private void FixedUpdate()
    {

        if (BufferedMain)
        {

            AttackScript.MainAttack();
            BufferedMain = false;

        }

        else if (BufferedSecondary)
        {

            AttackScript.SecondaryAttack();
            BufferedSecondary = false;

        }

    }


}
