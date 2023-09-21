using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradingSystem : MonoBehaviour
{
    public static UpgradingSystem instance;

    public StatsKendaraan Stats;

    public GameObject Kendaraan;

    public GameObject UIUpgrade;

    public PlayerCameraRotation playerCameraRotation;

    public PlayerMovement playerMovement;
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
        } else {
            Stats = null;
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

    public void Exit(){
        UIUpgrade.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
        playerCameraRotation.enabled = true;
    }
}
