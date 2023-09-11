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

    private void FixedUpdate()
    {
        
        if (statsMobil.StatsBensin <= 0)
        {
            currentAcceleration = 0f;
            currentBreakForce = 1000f;
            currentTurnAngle = 0f;
        }


        if (Driving && statsMobil.StatsBensin > 0)
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
        if (currentAcceleration >= 200f){
            currentAcceleration = 0f;
            trunkManager.MinusNyawa();

            if (statsMobil.StatsKesehatanMobil > 0)
            {

                statsMobil.StatsKesehatanMobil -= 1f;
            }
        }
        Debug.Log("Nabrak");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        trunkManager = GetComponentInChildren<TrunkManager>();
        statsMobil = GetComponentInChildren<StatsMobil>();
    }

    // Update is called once per frame
    void Update()
    {


        if ( currentAcceleration >= 300f)
        {

                statsMobil.StatsBensin -= 0.00002f;
            
        }

    }
}
