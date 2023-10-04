using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;

    [Header ("Player Kecepatan")]
    public float MoveSpeed;

    public float MoveSpeedMax;
    public float MoveSpeedMin;

    public float JumpForce;


    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Transform camPosition;

    public float playerVelocity;

    Vector3 moveDirection;

    Rigidbody rb;

    public float StatsStamina;

    public float StatsStaminaMax;

    public float StatsPerut;

    public float StatsPerutMax;



    //Waktu Hitung Mundur 

    public float CountDown;
    public float currentCountDown;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody> ();
        rb.freezeRotation = true;

        currentCountDown = CountDown;
    }

    // Update is called once per frame
    void Update()
    {
         grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
         
        if (currentCountDown <= 0) {

            StatsPerut -= 3f;
            currentCountDown = CountDown;
        
        } else
        {
            currentCountDown -= Time.deltaTime;
        }

        PlayerJump();
    }

    void FixedUpdate()
    {
        // Ground Check apakah nempel atau tidak
       


        if (grounded)
        {
             MovePlayer();
        }

       

        MyInput();

        SpeedControl();


        

        // If statement Drag atau tidak
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        
        
        
    }


    public void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift)){

            if (StatsStamina > 0)
            {
                if (MoveSpeed < MoveSpeedMax)
                {
                    MoveSpeed += 2;
                }

                if (StatsStamina > 0)
                {
                    StatsStamina -= 0.5f;
                }
            } else
            {
                if (MoveSpeed > MoveSpeedMin)
                {
                    MoveSpeed -= 2;
                }
            }
            

        } else {

            if (MoveSpeed > MoveSpeedMin){
                MoveSpeed -= 2;
            }

            if (StatsStamina < StatsStaminaMax)
            {
                StatsStamina += 0.2f;
            }
        }

        
    }

    public void PlayerJump(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if (grounded){
                rb.AddForce(this.transform.up * JumpForce, ForceMode.Impulse);
                Debug.Log("Lompat");
            } 
            
        }

        if (!grounded) {
                rb.AddForce(this.transform.up * -1, ForceMode.Impulse);
            }


    }

    public void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f , rb.velocity.z);

        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
