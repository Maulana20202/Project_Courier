using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WheelControllerMotor : MonoBehaviour
{
    public TrunkManager trunkManager;
    public Transform motor;

    public Rigidbody rb;

    [SerializeField] WheelCollider front;
    [SerializeField] WheelCollider back;

    [SerializeField] Transform frontTransform;
    [SerializeField] Transform backTransform;
    [SerializeField] Transform Stang;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    public float currentAcceleration = 0f;
    public float currentBreakForce = 0f;
    public float currentTurnAngle = 0f;

    public float responsiveness;

    public bool Driving;

    private void FixedUpdate()
    {

        

        if (Driving)
        {

            currentAcceleration = acceleration * Input.GetAxis("Vertical");

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
            var rotStang = Quaternion.Euler(eulerMotor.x, currentTurnAngle += eulerMotor.y, eulerMotor.z);


            Stang.rotation = rotStang;


            if (currentTurnAngle == 0)
            {
                motor.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (currentTurnAngle != 0)
            
            {
                rb.AddTorque(transform.right * currentTurnAngle);
            }
            
            


        }
        front.brakeTorque = currentBreakForce;
        back.brakeTorque = currentBreakForce;

        UpdateWheel(front, frontTransform);
        UpdateWheel(back, backTransform);


    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
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
        trunkManager = GetComponentInChildren<TrunkManager>();
        motor = this.gameObject.transform;

        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
