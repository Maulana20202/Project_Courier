using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mobil_Script : MonoBehaviour
{
    [SerializeField] private Transform[] PathPoints;

    public GameObject Player;

    public SpawnerMobil spawnerMobil;


    public int Index;

    public float MinimumDistance = 2;

    public float MaximumDistance = 2;

    public float speed = 3f;
    public Vector3 CarVelocity;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    public Transform Ray1;
    public Transform Ray2;

    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public float maxSteerAngle;

    public float maxTorque;

    public float maxBrakeTorque;


    public float RayDistance;

    public LayerMask mask;


    public WaypointAja waypoint;
    // Start is called before the first frame update
    void Start()
    {
        MaximumDistance = 100f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray r = new Ray(new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z), transform.forward);
        Ray r2 = new Ray(new Vector3 (Ray1.position.x, Ray1.position.y + 1f, Ray1.position.z), Ray1.forward);
        Ray r3 = new Ray(new Vector3 (Ray2.position.x, Ray2.position.y + 1f, Ray2.position.z), Ray2.forward);
        Debug.DrawRay(r.origin, r.direction * RayDistance);
        Debug.DrawRay(r2.origin, r2.direction * RayDistance);
        Debug.DrawRay(r3.origin, r3.direction * RayDistance);
        RaycastHit hitInfo;

        if(Physics.Raycast(r, out hitInfo, RayDistance) || Physics.Raycast(r2, out hitInfo, RayDistance) || Physics.Raycast(r3, out hitInfo, RayDistance)){
            maxTorque = 0f;
            maxBrakeTorque = 700f;
        } else {
            maxTorque = 100f;
            maxBrakeTorque = 0f;
        }

    }

    void FixedUpdate(){

        CarVelocity = GetComponent<Rigidbody>().transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        
        
        NgadepPoint();
        Drive();
        Roam();
        DeSpawn();
        
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);

        /*frontLeftTransform.localRotation = Quaternion.Slerp(frontLeftTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y , frontLeftTransform.localRotation.eulerAngles.z) , Agent.speed);
        frontRightTransform.localRotation = Quaternion.Slerp(frontRightTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y, frontRightTransform.localRotation.eulerAngles.z) , Agent.speed);
        backLeftTransform.localRotation = Quaternion.Slerp(backLeftTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y, backLeftTransform.localRotation.eulerAngles.z) , Agent.speed);
        backRightTransform.localRotation = Quaternion.Slerp(backRightTransform.localRotation,Quaternion.Euler(10f, frontLeftTransform.localRotation.eulerAngles.y, backRightTransform.localRotation.eulerAngles.z) , Agent.speed);*/
        
        
    }
    

    void Roam(){


       
     if(Vector3.Distance(transform.position, waypoint.transform.position) < MinimumDistance){

         if(waypoint.perempatan != null && waypoint.perempatan.Count > 0){

            int RandomAngka = Random.Range(0, waypoint.perempatan.Count);

            waypoint = waypoint.perempatan[RandomAngka];

        } else {
             waypoint = waypoint.nextWaypoint;
        }
           
        }
    }

    void NgadepPoint(){

        Vector3 RelativeVector = transform.InverseTransformPoint(waypoint.transform.position);
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

    void DeSpawn(){
        if(Vector3.Distance(transform.position, Player.transform.position) > MaximumDistance){
            spawnerMobil.Already_Spawn = false;
            Destroy(this.gameObject);
        }
    }
}

