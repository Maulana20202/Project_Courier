using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MotorController : MonoBehaviour
{
    public float maxSpeed, acceleration, turn;

    public Rigidbody rb, carBody;

    public AnimasiPengendara animasiPengendara;
    public Transform TitikKakiKiri;
    public Transform TitikAwalKaki;

    public AnimationCurve frictionCurve;
    public AnimationCurve turnCurve;
    public AnimationCurve leanCurve;
    public PhysicMaterial frictionMaterial;


    public Transform BodyMesh;
    public Transform Handle;
    public Transform[] Wheel;

    public TextMeshProUGUI text;

    public bool Driving;

    public Vector3 carVelocity;

    [Range(-70, 70)]

    public float BodyTilt;

    public float radius, horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Visuals();

    }

    void FixedUpdate()
    {
        

        if (Driving)
        {

            carVelocity = carBody.transform.InverseTransformDirection(carBody.velocity);

            if (Mathf.Abs(carVelocity.x) > 0)
            {
                //changes friction according to sideways speed of car
                frictionMaterial.dynamicFriction = frictionCurve.Evaluate(Mathf.Abs(carVelocity.x / 100));
            }

            float sign = Mathf.Sign(carVelocity.z);
            float TurnMultipler = turnCurve.Evaluate(carVelocity.magnitude / maxSpeed);

            if (verticalInput > 0.1f || carVelocity.z > 1)
            {
                carBody.AddTorque(Vector3.up * horizontalInput * sign * turn * 10 * TurnMultipler);

            }
            else if (verticalInput < -0.1f || carVelocity.z < -1)
            {

                carBody.AddTorque(Vector3.up * horizontalInput * sign * turn * 10 * TurnMultipler);
            }

            if (Input.GetAxis("Jump") > 0.1f)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
            }

            if (Mathf.Abs(verticalInput) > 0.1f || Input.GetAxis("Jump") < 1)
            {

                rb.velocity = Vector3.Lerp(rb.velocity, carBody.transform.forward * verticalInput * maxSpeed, acceleration / 10 * Time.deltaTime);

            } else {

                rb.velocity = Vector3.Lerp(rb.velocity, carBody.transform.forward * 0, 0.0000000001f * Time.deltaTime);
            }

            if (Mathf.Abs(carVelocity.z) <= 0.1f)
            {
                animasiPengendara.IKPoints[5].position = Vector3.Lerp(animasiPengendara.IKPoints[5].position, TitikKakiKiri.position, 0.1f);
            } else
            {
                animasiPengendara.IKPoints[5].position = Vector3.Lerp(animasiPengendara.IKPoints[5].position, TitikAwalKaki.position, 0.1f);
            }
        }
            

            
        
    }

    public void Visuals()
    {
        if (Driving)
        {
            Handle.localRotation = Quaternion.Slerp(Handle.localRotation, Quaternion.Euler(Handle.localRotation.eulerAngles.x,
                               10 * horizontalInput, Handle.localRotation.eulerAngles.z), 0.1f);

            Wheel[0].localRotation = rb.transform.localRotation;
            Wheel[1].localRotation = rb.transform.localRotation;

            //Body
            if (Mathf.Abs(carVelocity.z) > 1)
            {
                BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(0,
                                   BodyMesh.localRotation.eulerAngles.y, BodyTilt * horizontalInput * leanCurve.Evaluate(carVelocity.z / maxSpeed)), 0.02f);
            }
            else
            {
                BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(0, 0, 0), 0.02f);
            }
        }

        



    }
}
