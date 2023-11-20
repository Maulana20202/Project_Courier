using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PindahKota : interactable
{

    public GameObject UIPindahKota;

    public PlayerMovement playerMovement;

    public PlayerCameraRotation playerCameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     protected override void Interact()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCameraRotation = FindObjectOfType<PlayerCameraRotation>();
        
        UIPindahKota.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovement.enabled = false;
        playerCameraRotation.enabled = false;

    }
}
