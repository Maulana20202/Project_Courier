using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradingSystem : MonoBehaviour
{
    public static UpgradingSystem instance;

    public StatsKendaraan Stats;

    public GameObject Kendaraan;

    public GameObject UIUpgrade;

    public PlayerCameraRotation playerCameraRotation;

    public PlayerMovement playerMovement;

    public GameObject CanvasBensinValue;
    public GameObject CanvasKondisiValue;
    public GameObject CanvasMuatanValue;

    public MotorController motorController;
    public WheelController mobilController;
    public Slider Kondisi;

    public Image GambarKendaraan;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start(){
        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Kendaraan != null){
            Stats = Kendaraan.GetComponentInChildren<StatsKendaraan>();
            GambarKendaraan.sprite = Stats.GambarKendaraan;
        } else {
            Stats = null;
        }

    if (Kendaraan != null){
        if(Stats.gameObject.GetComponent<MotorController>() != null){
            motorController = Stats.gameObject.GetComponent<MotorController>();
            Kondisi.maxValue = motorController.KondisiKendaraanValueMax;
            Kondisi.value = motorController.KondisiKendaraanValue;
        } else if (Stats.gameObject.GetComponent<WheelController>() != null){
            mobilController = Stats.gameObject.GetComponent<WheelController>();
            Kondisi.maxValue = mobilController.KondisiKendaraanValueMax;
            Kondisi.value = mobilController.KondisiKendaraanValue;
        }
    }

        //Pengatur Stats Upgrade Bensin Udah Berapa

        if(Stats != null){
            if(Stats.StatsBensin == 1){
                CanvasBensinValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(1).gameObject.SetActive(false);
                CanvasBensinValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasBensinValue.transform.GetChild(3).gameObject.SetActive(false);
            } else if(Stats.StatsBensin == 2){
                CanvasBensinValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasBensinValue.transform.GetChild(3).gameObject.SetActive(false);
            }
             else if(Stats.StatsBensin == 3){
                CanvasBensinValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(2).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if(Stats.StatsBensin == 4){
                CanvasBensinValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(2).gameObject.SetActive(true);
                CanvasBensinValue.transform.GetChild(3).gameObject.SetActive(true);
            } else {
                CanvasBensinValue.transform.GetChild(0).gameObject.SetActive(false);
                CanvasBensinValue.transform.GetChild(1).gameObject.SetActive(false);
                CanvasBensinValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasBensinValue.transform.GetChild(3).gameObject.SetActive(false);
            }

            //Pengatur Stats Upgrade Muatan Udah Berapa

            if(Stats.StatsMuatan == 1){
                CanvasMuatanValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(1).gameObject.SetActive(false);
                CanvasMuatanValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasMuatanValue.transform.GetChild(3).gameObject.SetActive(false);
            } else if(Stats.StatsMuatan == 2){
                CanvasMuatanValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasMuatanValue.transform.GetChild(3).gameObject.SetActive(false);
            }
             else if(Stats.StatsMuatan == 3){
                CanvasMuatanValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(2).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if(Stats.StatsMuatan == 4){
                CanvasMuatanValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(2).gameObject.SetActive(true);
                CanvasMuatanValue.transform.GetChild(3).gameObject.SetActive(true);
            } else {
                CanvasMuatanValue.transform.GetChild(0).gameObject.SetActive(false);
                CanvasMuatanValue.transform.GetChild(1).gameObject.SetActive(false);
                CanvasMuatanValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasMuatanValue.transform.GetChild(3).gameObject.SetActive(false);
            
            }

            //Pengatur Stats Upgrade kondisi Udah Berapa

            if(Stats.StatsKondisi == 1){
                CanvasKondisiValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(1).gameObject.SetActive(false);
                CanvasKondisiValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasKondisiValue.transform.GetChild(3).gameObject.SetActive(false);
            } else if(Stats.StatsKondisi == 2){
                CanvasKondisiValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasKondisiValue.transform.GetChild(3).gameObject.SetActive(false);
            }
             else if(Stats.StatsKondisi == 3){
                CanvasKondisiValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(2).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if(Stats.StatsKondisi == 4){
                CanvasKondisiValue.transform.GetChild(0).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(1).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(2).gameObject.SetActive(true);
                CanvasKondisiValue.transform.GetChild(3).gameObject.SetActive(true);
            } else {
                CanvasKondisiValue.transform.GetChild(0).gameObject.SetActive(false);
                CanvasKondisiValue.transform.GetChild(1).gameObject.SetActive(false);
                CanvasKondisiValue.transform.GetChild(2).gameObject.SetActive(false);
                CanvasKondisiValue.transform.GetChild(3).gameObject.SetActive(false);
            
            }
            
        }
        
    }


    public void UpgradeBensin(){
        
        Stats.BaseUpgradingBensin();
        
    }

    public void UpgradeKeadaanKendaraan(){
        Stats.BaseUpgradingKondisi();
        
    }

    public void UpgradeMuatan(){
        Stats.BaseUpgradingMuatan();
        
    }

    public void IsiBensin(){
        Stats.BaseMengisiBensin();
    }

    public void KondisiMembaik(){
        Stats.BaseMengisiKondisi();
    }

    public void Exit(){
        UIUpgrade.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
        playerCameraRotation.enabled = true;

        Debug.Log("Kepencet");
    }
}
