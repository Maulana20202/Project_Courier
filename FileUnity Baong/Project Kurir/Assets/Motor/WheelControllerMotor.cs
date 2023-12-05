using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WheelControllerMotor : MonoBehaviour
{
    public TrunkManager trunkManager;
    public Transform motor;

    public Rigidbody rb;

    public PlayerCameraRotation playerCameraRotation;

    public PlayerMovement playerMovement;

    [SerializeField] WheelCollider front;
    [SerializeField] WheelCollider back;

    [SerializeField] Transform frontTransform;
    [SerializeField] Transform backTransform;
    [SerializeField] Transform Stang;

    [SerializeField] Transform BodyMesh;

     [Range(-70, 70)]

    public float BodyTilt;

    public AnimationCurve leanCurve;

    public SaveanValueMotor saveanMotor;

    public ManagerUI managerUI;

    public Vector3 carVelocity;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    public float horizontalInput;

    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;
    public float currentTurnAngle = 0f;

    [Header("Bensin value")]

    public float BensinValueMin = 100;
    public float BensinValueMax = 100;
    public float BensinValue = 100;

    [Header("Kondisi Kendaraan value")]
    
    public float KondisiKendaraanValueMin = 100;
    public float KondisiKendaraanValueMax = 100;

    public float KondisiKendaraanValue = 100;

    public float WaktuNgurang;

    public float WaktuNgurangCurrent;

    public Animator animasiBlack;


    public float responsiveness;

    public bool Driving;

    public float stangX;

    public float stangZ;

    private void FixedUpdate()
    {

        
        carVelocity = rb.transform.InverseTransformDirection(rb.velocity);
        
        if (Driving)
        {

            currentAcceleration = acceleration * Input.GetAxis("Vertical") * -1;

            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakingForce;
            }
            else
            {
                currentBreakForce = 0f;
            }

            back.motorTorque = currentAcceleration;



            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            front.steerAngle = currentTurnAngle;

            

            var eulerMotor = motor.rotation.eulerAngles;
            var rotStang = Quaternion.Euler(eulerMotor.x + stangX, currentTurnAngle + eulerMotor.y, eulerMotor.z + stangZ);


            Stang.rotation = rotStang;
            
            
            


        }
        front.brakeTorque = currentBreakForce;
        back.brakeTorque = currentBreakForce;

        UpdateWheel(front, frontTransform);
        UpdateWheel(back, backTransform);


    }

    void Update(){

            horizontalInput = Input.GetAxis("Horizontal");

            visuals();

            if(carVelocity.z < -1){
                if(WaktuNgurangCurrent <= 0){
                    BensinValue -= 5;
                    WaktuNgurangCurrent = WaktuNgurang;
                } else {
                    WaktuNgurangCurrent -= Time.deltaTime;
                }
            }

            saveanMotor.BensinValueMax = BensinValueMax;
            saveanMotor.KondisiValueMax = KondisiKendaraanValueMax;
            saveanMotor.BensinCurrent = BensinValue;
            saveanMotor.KondisiCurrent = KondisiKendaraanValue;

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    void SliderUI(){
        managerUI.UIBensinSlider.maxValue = BensinValueMax;

        managerUI.UIBensinSlider.value = BensinValue;

        managerUI.UIKondisiSlider.maxValue = KondisiKendaraanValueMax;

        managerUI.UIKondisiSlider.value = KondisiKendaraanValue;
    }


    /*
    void OnCollisionEnter(Collision col)
    {
        if (currentAcceleration >= 200f)
        {
            currentAcceleration = 0f;
            trunkManager.MinusNyawa();
        }
        Debug.Log("Nabrak");

    }
    */
    


    // Start is called before the first frame update
    void Start()
    {
         BensinValueMax = saveanMotor.BensinValueMax;
        KondisiKendaraanValueMax = saveanMotor.KondisiValueMax;

        trunkManager = GetComponentInChildren<TrunkManager>();
        motor = this.gameObject.transform;

        rb = this.gameObject.GetComponent<Rigidbody>();

        managerUI = FindAnyObjectByType<ManagerUI>();

        trunkManager = GetComponentInChildren<TrunkManager>();

        animasiBlack = GameObject.FindWithTag("BlackScreen").GetComponent<Animator>();

        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();

        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }


    void visuals(){
        if (Mathf.Abs(carVelocity.z) > 1)
            {
                motor.localRotation = Quaternion.Slerp(motor.localRotation, Quaternion.Euler(0,
                                   motor.localRotation.eulerAngles.y, BodyTilt * horizontalInput * leanCurve.Evaluate(carVelocity.z / acceleration * -1f)), 0.02f);
            }
            else
            {
                motor.localRotation = Quaternion.Slerp(motor.localRotation, Quaternion.Euler(0, 0, 0), 0.02f);
            }
    }

    // Update is called once per fram
}
