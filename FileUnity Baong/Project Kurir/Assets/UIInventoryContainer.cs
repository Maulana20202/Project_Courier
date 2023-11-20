using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryContainer : MonoBehaviour
{
    public static UIInventoryContainer instance;
    public Transform ItemContent;

    public GameObject InventoryCanvas;

    public GameObject ItemInventory;

    public PlayerMovement playerMovement;

    public PlayerCameraRotation playerCameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        InventoryCanvas = GameObject.FindWithTag("Inventory").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

    }

    public void Exit(){
        
            InventoryCanvas.SetActive(false);

            playerCameraRotation = FindObjectOfType<PlayerCameraRotation>();
            playerMovement = FindObjectOfType<PlayerMovement>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerMovement.enabled = true;
            playerCameraRotation.enabled = true;

    }

}
