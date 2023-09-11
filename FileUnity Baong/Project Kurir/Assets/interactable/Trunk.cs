using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Trunk : interactable
{

    public GameObject InventoryCanvas;
    public GameObject Inventory;
    public PlayerMovement playerMovement;
    public PlayerCameraRotation playerCameraRotation;

    public TrunkManager trunkManager;

    public BoxStats boxStats;

    public float NyawaBarang;

    public float beratBarang;

    public float beratBarangCurrent;

    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas = GameObject.FindWithTag("Inventory");
        Inventory = InventoryCanvas.transform.GetChild(0).gameObject;
        playerMovement = FindObjectOfType<PlayerMovement>();
        

        trunkManager = GetComponent<TrunkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCameraRotation = FindObjectOfType<PlayerCameraRotation>();
         boxStats = BoxStatsContainer.Instance.boxStatus;
         NyawaBarang = BoxStatsContainer.Instance.nyawaBarang;

    }

    protected override void Interact()
    {
        Inventory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovement.enabled = false;
        playerCameraRotation.enabled = false;

        trunkManager.listItem();
        this.gameObject.tag = "MainTrunk";
        InventoryController.Instance.Bagasi = this.gameObject;

    }

    protected override void InteractAlter()
    {
        if (beratBarangCurrent < beratBarang)
        {
            beratBarangCurrent += boxStats.Berat;
            trunkManager.Add(boxStats, NyawaBarang);
            trunkManager.ForDestroy(BoxStatsContainer.Instance.boxStatsObject);

        }
       
    }

}
