using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteksiKendaraan : MonoBehaviour
{

    public GameObject Kendaraan;

    public int CountingKendaraan;

    public void Update(){

        if (Kendaraan != null){
            UpgradingSystem.instance.Kendaraan = Kendaraan; 
        }
        
    }
    
    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Kendaraan"){
            CountingKendaraan += 1;
            if(CountingKendaraan == 1){
                Kendaraan = col.gameObject;
                Debug.Log("yang masuk Kendaraan" + col.transform.name);
            }
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Kendaraan"){
            CountingKendaraan -= 1;
            Kendaraan = null;
            if(CountingKendaraan == 1){
                
                Debug.Log("yang keluar Kendaraan" + col.transform.name);
            }
        }
    }
}
