using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Mobil_Script : MonoBehaviour
{
    [SerializeField] private Transform[] PathPoints;


    public int Index;

    public float MinimumDistance = 2;

    public float speed = 3f;
    public Vector3 CarVelocity;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public float maxSteerAngle;

    public float maxTorque;

    public float maxBrakeTorque;


    public float RayDistance;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Ray r = new Ray(new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z), transform.forward);
        Debug.DrawRay(r.origin, r.direction * RayDistance);
        RaycastHit hitInfo;

        if(Physics.Raycast(r, out hitInfo, RayDistance)){
            maxTorque = 0f;
            maxBrakeTorque = 700f;
        } else {
            maxTorque = 100f;
            maxBrakeTorque = 0f;
        }

    }

    void FixedUpdate(){

        CarVelocity = GetComponent<Rigidbody>().transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
            
        Roam();
        NgadepPoint();
        Drive();

        /*frontLeftTransform.localRotation = Quaternion.Slerp(frontLeftTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y , frontLeftTransform.localRotation.eulerAngles.z) , Agent.speed);
        frontRightTransform.localRotation = Quaternion.Slerp(frontRightTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y, frontRightTransform.localRotation.eulerAngles.z) , Agent.speed);
        backLeftTransform.localRotation = Quaternion.Slerp(backLeftTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y, backLeftTransform.localRotation.eulerAngles.z) , Agent.speed);
        backRightTransform.localRotation = Quaternion.Slerp(backRightTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y, backRightTransform.localRotation.eulerAngles.z) , Agent.speed);*/
        
        
    }
    

    void Roam(){

     if(Vector3.Distance(transform.position, PathPoints[Index].position) < MinimumDistance){
            if(Index >= 0 && Index < PathPoints.Length - 1){         
                Index += 1;
            } else {
                Index = 0;
            }
        }
    }

    void NgadepPoint(){

        Vector3 RelativeVector = transform.InverseTransformPoint(PathPoints[Index].position);
        float newSteer = RelativeVector.x / RelativeVector.magnitude * maxSteerAngle;
        frontRight.steerAngle = newSteer;
        frontLeft.steerAngle = newSteer;

    }

    void Drive(){
        backRight.motorTorque = maxTorque;
        backLeft.motorTorque = maxTorque;

        backRight.brakeTorque= maxBrakeTorque;
        backLeft.brakeTorque = maxBrakeTorque;
        frontRight.brakeTorque= maxBrakeTorque;
        frontLeft.brakeTorque = maxBrakeTorque;
    }




    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}

