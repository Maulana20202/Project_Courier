using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBengkel : interactable
{

    public DeteksiKendaraan detekKendaraan;

    public MotorController motorYangDimodif;

    public GameObject UIUpgrade;

    public PlayerCameraRotation playerCameraRotation;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (detekKendaraan.Kendaraan != null){
            motorYangDimodif = detekKendaraan.Kendaraan.GetComponent<MotorController>();

        } else {
            motorYangDimodif = null;
        }
        
    }


    protected override void Interact(){
        UIUpgrade.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovement.enabled = false;
        playerCameraRotation.enabled = false;
    }
}
