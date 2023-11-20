using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    public TrunkManager trunkManager;

    public StatsMobil statsMobil;



    public ManagerUI managerUI;

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 1000f;
    public float breakingForce = 300f;
    public float maxTurnAngle;

    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;
    public float currentTurnAngle = 0f;

    public bool Driving;

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

    //Savean

    public SaveanValueMotor saveanMotor;

    private void FixedUpdate()
    {
        


        if (Driving)
        {
            currentAcceleration = acceleration * Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakingForce;
            } else
            {
                currentBreakForce = 0f;
            }

            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;

            

            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;


        }
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

     void OnCollisionEnter(Collision col){
        if (Mathf.Abs(currentAcceleration) >= 1){
            KondisiKendaraanValue -= 5;
        }

        trunkManager.MinusNyawa();
    }
    // Start is called before the first frame update
    void Start()
    {
        trunkManager = GetComponentInChildren<TrunkManager>();
        statsMobil = GetComponentInChildren<StatsMobil>();
        managerUI = FindAnyObjectByType<ManagerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(currentAcceleration) > 1){
            if(WaktuNgurangCurrent <= 0){
                BensinValue -= 5;
                WaktuNgurangCurrent = WaktuNgurang;
            } else {
                WaktuNgurangCurrent -= Time.deltaTime;
            }
        }

        saveanMotor.BensinValueMax = BensinValueMax;
        saveanMotor.KondisiValueMax = KondisiKendaraanValueMax;

        SliderUI();

    }

    void SliderUI(){
        managerUI.UIBensinSlider.maxValue = BensinValueMax;

        managerUI.UIBensinSlider.value = BensinValue;

        managerUI.UIKondisiSlider.maxValue = KondisiKendaraanValueMax;

        managerUI.UIKondisiSlider.value = KondisiKendaraanValue;
    }

   
}
