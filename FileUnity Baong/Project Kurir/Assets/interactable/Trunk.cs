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

    public List<GameObject> TempatBarang = new List<GameObject>();

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



         float Barang_25 = beratBarang * 0.25f;

         float Barang_50 = beratBarang * 0.50f; 

         float Barang_75 = beratBarang * 0.75f; 

         float Barang_100 = beratBarang * 1f;

         if (beratBarangCurrent < Barang_25){
            TempatBarang[0].SetActive(false);
            TempatBarang[1].SetActive(false);
            TempatBarang[2].SetActive(false);
            TempatBarang[3].SetActive(false);
         } 

         if(beratBarangCurrent >= Barang_25){
            TempatBarang[0].SetActive(true);
            TempatBarang[1].SetActive(false);
            TempatBarang[2].SetActive(false);
            TempatBarang[3].SetActive(false);
         }
         
         if(beratBarangCurrent >= Barang_50){
            TempatBarang[0].SetActive(true);
            TempatBarang[1].SetActive(true);
            TempatBarang[2].SetActive(false);
            TempatBarang[3].SetActive(false);
         }
         
         if(beratBarangCurrent >= Barang_75){
            TempatBarang[0].SetActive(true);
            TempatBarang[1].SetActive(true);
            TempatBarang[2].SetActive(true);
            TempatBarang[3].SetActive(false);
         }
         
         if(beratBarangCurrent >= Barang_100){
            TempatBarang[0].SetActive(true);
            TempatBarang[1].SetActive(true);
            TempatBarang[2].SetActive(true);
            TempatBarang[3].SetActive(true);
         }
         


         

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
            beratBarangCurrent = 0;
            trunkManager.Add(boxStats, NyawaBarang);
            trunkManager.ForDestroy(BoxStatsContainer.Instance.boxStatsObject);

            for (int i = 0; i < trunkManager.Items.Count;i++ ){
            beratBarangCurrent += trunkManager.Items[i].Berat;
        }

        }
       
    }

}
