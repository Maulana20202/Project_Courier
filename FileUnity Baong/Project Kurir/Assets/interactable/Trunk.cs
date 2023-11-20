using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public float beratBarangMin;

    public float beratBarangCurrent;

    public bool NgitungBerat;

    public TextMeshProUGUI KapasitasCurrent;

    public TextMeshProUGUI KapasitasMax;

    //savean

    public SaveanValueMotor saveanMotor;

    // Start is called before the first frame update
    void Start()
    {
        InventoryCanvas = GameObject.FindWithTag("Inventory");
        Inventory = InventoryCanvas.transform.GetChild(0).gameObject;
        playerMovement = FindObjectOfType<PlayerMovement>();
        
        NgitungBerat = true;
        trunkManager = GetComponent<TrunkManager>();
        
        beratBarang = saveanMotor.MuatanValueMax;
    }

    // Update is called once per frame
    void Update()
    {
        playerCameraRotation = FindObjectOfType<PlayerCameraRotation>();
         boxStats = BoxStatsContainer.Instance.boxStatus;
         NyawaBarang = BoxStatsContainer.Instance.nyawaBarang;

        saveanMotor.MuatanValueMax = beratBarang;


        if(NgitungBerat == true){
            if(trunkManager.Items.Count >= 0){
                int CheckPoint = trunkManager.Items.Count;
                int CheckPointMinus = CheckPoint -= 1;
                beratBarangCurrent = 0;
                for (int i = 0; i < trunkManager.Items.Count;i++ ){

                    if (i == CheckPointMinus){
                    NgitungBerat = false;
                    }
                beratBarangCurrent += trunkManager.Items[i].Berat;
            }
            
        }

        }


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
            KapasitasCurrent = InventoryCanvas.transform.GetChild(0).transform.GetChild(5).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            KapasitasMax = InventoryCanvas.transform.GetChild(0).transform.GetChild(5).transform.GetChild(2).GetComponent<TextMeshProUGUI>();

            KapasitasCurrent.text = beratBarangCurrent.ToString();
            KapasitasMax.text = beratBarang.ToString();
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
                if(BoxStatsContainer.Instance.boxStatus != null){
                    
                trunkManager.Add(BoxStatsContainer.Instance.boxStatus, BoxStatsContainer.Instance.nyawaBarang);
                trunkManager.ForDestroy(BoxStatsContainer.Instance.boxStatsObject);
                BoxStatsContainer.Instance.boxStatus = null;
                BoxStatsContainer.Instance.nyawaBarang = 0;
                NgitungBerat = true;
                BoxStatsContainer.Instance.AngkutBarang = false;

                }

            }
    }

}
