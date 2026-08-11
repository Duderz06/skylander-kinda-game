using UnityEngine;
using UnityEngine.UIElements;

public class AttackHandler : MonoBehaviour
{
    private PlayerControls Input;

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


    void Awake()
    {
        Input = new PlayerControls();

    }

    void OnEnable()
    {

        Input.Enable();

    }

    void OnDisable()
    {

        Input.Disable();

    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.gameplay.mainattack.WasPressedThisFrame() && !BufferedSecondary && CanAttack && CanMain)
        {


            BufferedMain = true;

        }

        if (Input.gameplay.secondaryattack.WasPressedThisFrame() && !BufferedMain && UH.SecondaryMove && CanAttack && CanSecondary)
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
