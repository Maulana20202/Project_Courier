using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Mobil : interactable
{

    public WheelController controllerMobil;
    public GameObject playerUtama;
    public Transform TitikDuduk;
    public Transform TitikTurun;

    public GameObject camKendaraan;
    public GameObject camUtama;

    public PlayerMovement playerMovement;
    public CapsuleCollider capsuleCollider;
    public Rigidbody rb;

    public Transform mobil;

    public bool NaikMobil;

    public GameObject StatsPlayer;

    public GameObject StatsKendaraan;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        controllerMobil = mobil.GetComponent<WheelController>();
        playerUtama = GameObject.FindWithTag("PlayerUtama");
        playerMovement = playerUtama.GetComponent<PlayerMovement>();
        capsuleCollider = playerUtama.GetComponentInChildren<CapsuleCollider>();
        rb = playerUtama.GetComponent <Rigidbody>();
        camUtama = GameObject.FindWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (NaikMobil == true)
            {

                camUtama.SetActive(true);
                camKendaraan.SetActive(false);
                NaikMobil = false;
                playerUtama.transform.position = TitikTurun.position;
                controllerMobil.currentBreakForce = 500f;
                controllerMobil.currentAcceleration = 0f;
                controllerMobil.currentTurnAngle = 0f;
                controllerMobil.Driving = false;
                playerMovement.enabled = true;

                capsuleCollider.enabled = true;
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                playerUtama.transform.SetParent(null);
                PlayerInteract.instance.player.SetActive(true);
                Debug.Log("kepencet Lgi");

                StatsKendaraan.SetActive(false);
                StatsPlayer.SetActive(true);

            }
        }
    }

    protected override void Interact()
    {

        StartCoroutine("NaikMobilDelay");

    }



    private IEnumerator NaikMobilDelay()
    {
        
        camUtama.SetActive(false);
        camKendaraan.SetActive(true);

        
        playerMovement.enabled = false;

        capsuleCollider.enabled = false;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        playerUtama.transform.SetParent(mobil);
        PlayerInteract.instance.player.SetActive(false);
        playerUtama.transform.position = TitikDuduk.position;
        PlayerInteract.instance.playerUI.UpdateText(string.Empty);
        StatsKendaraan.SetActive(true);
        StatsPlayer.SetActive(false);
        yield return new WaitForSeconds(1f);
        controllerMobil.Driving = true;
        NaikMobil = true;

        

        

        Debug.Log("kepencet");
       
    }

    
}
