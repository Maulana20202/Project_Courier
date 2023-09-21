using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Motor : interactable
{
    public MotorController controllerMobil;
    public GameObject playerUtama;
    public Transform TitikDuduk;
    public Transform TitikTurun;

    public GameObject Rider;

    public GameObject camKendaraan;
    public GameObject camUtamaParent;

    public GameObject camUtama;

    public PlayerMovement playerMovement;
    public CapsuleCollider capsuleCollider;
    public Rigidbody rb;

    public Transform mobil;

    public bool NaikMobil;
    
    public ManagerUI managerUI;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        playerUtama = GameObject.FindWithTag("PlayerUtama");
        playerMovement = playerUtama.GetComponent<PlayerMovement>();
        capsuleCollider = playerUtama.GetComponentInChildren<CapsuleCollider>();
        rb = playerUtama.GetComponent<Rigidbody>();
        
        camUtamaParent = GameObject.FindWithTag("MainCamera");

        managerUI = FindAnyObjectByType<ManagerUI>();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if(camUtamaParent.transform.GetChild(0).gameObject != null){
            camUtama = camUtamaParent.transform.GetChild(0).gameObject;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (NaikMobil == true)
            {

                camUtama.SetActive(true);
                camKendaraan.SetActive(false);
                NaikMobil = false;
                controllerMobil.Driving = false;
                playerMovement.enabled = true;
                rb.useGravity = true;
                capsuleCollider.enabled = true;
                playerUtama.transform.SetParent(null);
                PlayerInteract.instance.player.SetActive(true);
                Rider.SetActive(false);
                Debug.Log("kepencet Lgi");
                managerUI.WalkingUI();

                

            }
        }
        if(KENDARAANSCENEBARU.instance != null){
            if (KENDARAANSCENEBARU.instance.SpawnKendaraan == true){
                    StartCoroutine("NaikMobilDelay");
                    KENDARAANSCENEBARU.instance.SpawnKendaraan = false;
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
        playerUtama.transform.SetParent(mobil);
        Rider.SetActive(true);
        PlayerInteract.instance.player.SetActive(false);
        PlayerInteract.instance.playerUI.UpdateText(string.Empty);
        managerUI.RidingUI();
        yield return new WaitForSeconds(1f);
        controllerMobil.Driving = true;
        NaikMobil = true;
        



        Debug.Log("kepencet");

    }

    public void NaikMotorStart(){
        camKendaraan.SetActive(true);
        controllerMobil.Driving = true;
        PlayerInteract.instance.player.SetActive(false);
        PlayerInteract.instance.playerUI.UpdateText(string.Empty);
        Rider.SetActive(true);
        NaikMobil = true;
    }
}
