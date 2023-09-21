using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements.Experimental;

public class MotorController : MonoBehaviour
{
    public float maxSpeed,maxMundur, acceleration, turn;

    public Rigidbody rb, carBody;

    public Animator animateMundur;

    public AnimasiPengendara animasiPengendara;
    public Transform TitikKakiKiri;
    public Transform TitikAwalKaki;

    public AnimationCurve frictionCurve;
    public AnimationCurve turnCurve;
    public AnimationCurve leanCurve;
    public PhysicMaterial frictionMaterial;


    //Ground Check
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;


    public Transform BodyMesh;
    public Transform Handle;
    public Transform[] Wheel;

    public TextMeshProUGUI text;

    public bool Driving;

    public Vector3 carVelocity;

    [Range(-70, 70)]

    public float BodyTilt;

    public float radius, horizontalInput, verticalInput;

    //value Bensin Dan Kondisi Kendaraan

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

    //Manager UI

    public ManagerUI managerUI;

    // Start is called before the first frame update
    void Start()
    {
        BensinValueMax = saveanMotor.BensinValueMax;
        KondisiKendaraanValueMax = saveanMotor.KondisiValueMax;

        managerUI = FindAnyObjectByType<ManagerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical") * -1f;
        Visuals();


        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f - 0.2f, whatIsGround);

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

        SliderUI();
       
    }

    void FixedUpdate()
    {

        

        if (Driving)
        {

            carBody.isKinematic = false;

            carVelocity = carBody.transform.InverseTransformDirection(carBody.velocity);

            /*if (Mathf.Abs(carVelocity.x) > 0)
            {
                //changes friction according to sideways speed of car
                frictionMaterial.dynamicFriction = frictionCurve.Evaluate(Mathf.Abs(carVelocity.x / 100));
            }*/

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

            if (verticalInput < 0.1f)
            {

                rb.velocity = Vector3.Lerp(rb.velocity, carBody.transform.forward * verticalInput * maxSpeed, acceleration / 10 * Time.deltaTime);

            } else {
                rb.velocity = Vector3.Lerp(rb.velocity, carBody.transform.forward * verticalInput * maxMundur, acceleration / 10 * Time.deltaTime);
            }

            if (carVelocity.z >= -0.1f)
            {
                animasiPengendara.IKPoints[5].position = Vector3.Lerp(animasiPengendara.IKPoints[5].position, TitikKakiKiri.position, 0.1f);
            } else
            {
                animasiPengendara.IKPoints[5].position = Vector3.Lerp(animasiPengendara.IKPoints[5].position, TitikAwalKaki.position, 0.1f);
            }

            if (carVelocity.z > 0.5f){

                animateMundur.SetBool("Mundur", true);
            } else {
                animateMundur.SetBool("Mundur", false);
            }
        } else {


             if (grounded){
            carBody.isKinematic = true;
        } else {
            carBody.isKinematic = false;
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
                                   BodyMesh.localRotation.eulerAngles.y, BodyTilt * horizontalInput * leanCurve.Evaluate(carVelocity.z / maxSpeed * -1f)), 0.02f);
            }
            else
            {
                BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(0, 0, 0), 0.02f);
            }
        }

        



    }

    void OnCollisionEnter(Collision col){
        if (Mathf.Abs(carVelocity.z) >= 1){
            KondisiKendaraanValue -= 5;
        }
    }

    void SliderUI(){
        managerUI.UIBensinSlider.maxValue = BensinValueMax;

        managerUI.UIBensinSlider.value = BensinValue;

        managerUI.UIKondisiSlider.maxValue = KondisiKendaraanValueMax;

        managerUI.UIKondisiSlider.value = KondisiKendaraanValue;
    }
}
