using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    public GameObject Inventory;
    public PlayerMovement playerMovement;
    public PlayerCameraRotation playerCameraRotation;

    public GameObject Bagasi;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCameraRotation = FindObjectOfType<PlayerCameraRotation>();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TutupInventory()
    {
        Inventory.SetActive(false);
        playerMovement.enabled = true;
        playerCameraRotation.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Bagasi.tag = "Untagged";
    }
}
