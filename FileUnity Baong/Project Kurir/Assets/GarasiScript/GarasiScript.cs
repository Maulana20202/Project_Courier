using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GarasiScript : MonoBehaviour
{
    public List<GameObject> Kendaraan = new List<GameObject>();

    public List<GameObject> KendaraanBlack = new List<GameObject>();

    public List<int> KendaraanHarga = new List<int>();

    public SaveUIValue SaveUI;

    public int IndexKendaraan;

    public TextMeshProUGUI Harga;

    public Transform SpawnTitik;

    public GameObject KendaraanSpawnCurrent;

    public GameObject KendaraanSpawn;


    //Reference Cam

    public GameObject camBagasi;

    public GameObject camPlayer;

    public GameObject UIGameplay;

    public GameObject UIGarasi;

    public GameObject UIValueBensin;

    public GameObject UIValueKondisi;

    public GameObject UIValueMuatan;

    public MotorController motorController;

    public WheelController mobilController;

    public GameObject BeliButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Update(){

        SaveUI.KendaraanYangDigunakan = KendaraanSpawn;

        
        if(motorController != null || mobilController != null){
            VisualUpdate();
        }
        
        
        

    }
    

    public void InstantiateKendaraanNambah(){

        if(IndexKendaraan < Kendaraan.Count - 1){

            IndexKendaraan ++;

            if(GameManager.Instance.UnlockKendaraan[IndexKendaraan] != true){
                Destroy(KendaraanSpawnCurrent);

                KendaraanSpawnCurrent = Instantiate(KendaraanBlack[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);

                Harga.text = string.Format(CultureInfo.CreateSpecificCulture ("id-id"), "Rp {0:N0}", KendaraanHarga[IndexKendaraan]);

                KendaraanSpawn = null;

                BeliButton.SetActive(true);

                AmbilComponentController();

                
            } else if(GameManager.Instance.UnlockKendaraan[IndexKendaraan] == true){
                Destroy(KendaraanSpawnCurrent);

                KendaraanSpawnCurrent = Instantiate(Kendaraan[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);

                KendaraanSpawn = Kendaraan[IndexKendaraan];

                Harga.text = null;

                BeliButton.SetActive(false);

                AmbilComponentController();
            }

            
            
        }
    }


    public void InstantiateKendaraanKurang(){
        if(IndexKendaraan > 1){

            IndexKendaraan --;

            if(GameManager.Instance.UnlockKendaraan[IndexKendaraan] != true){
                Destroy(KendaraanSpawnCurrent);

                KendaraanSpawnCurrent = Instantiate(KendaraanBlack[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);

                Harga.text = string.Format(CultureInfo.CreateSpecificCulture ("id-id"), "Rp {0:N0}", KendaraanHarga[IndexKendaraan]);

                KendaraanSpawn = null;

                BeliButton.SetActive(true);

                AmbilComponentController();

                

                
            } else if(GameManager.Instance.UnlockKendaraan[IndexKendaraan] == true){
                Destroy(KendaraanSpawnCurrent);               

                KendaraanSpawnCurrent = Instantiate(Kendaraan[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);

                KendaraanSpawn = Kendaraan[IndexKendaraan];
                Harga.text = null;

                BeliButton.SetActive(false);

                AmbilComponentController();
            }
            

        }

        
    }


    public void Konfirmasi(){

        camBagasi.SetActive(false);
        camPlayer.SetActive(true);

        UIGameplay.SetActive(true);
        UIGarasi.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void SpawnPertama(){

        if(KendaraanSpawnCurrent != null){
            Destroy(KendaraanSpawnCurrent);
        }

        if(GameManager.Instance.UnlockKendaraan[IndexKendaraan] != true){
            KendaraanSpawnCurrent = Instantiate(KendaraanBlack[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);
            KendaraanSpawn = Kendaraan[IndexKendaraan];
            BeliButton.SetActive(true);
            Harga.text = string.Format(CultureInfo.CreateSpecificCulture ("id-id"), "Rp {0:N0}", KendaraanHarga[IndexKendaraan]);
        } else if(GameManager.Instance.UnlockKendaraan[IndexKendaraan] == true){
            KendaraanSpawnCurrent = Instantiate(Kendaraan[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);
            KendaraanSpawn = Kendaraan[IndexKendaraan];
            Harga.text = null;
            BeliButton.SetActive(false);
        }

        AmbilComponentController();
        VisualUpdate();
    }


    public void AmbilComponentController(){
        if(KendaraanSpawnCurrent.GetComponent<WheelController>() != null){
            mobilController = KendaraanSpawnCurrent.GetComponent<WheelController>();
        } else {
            mobilController = null;
        }

        if(KendaraanSpawnCurrent.GetComponent<MotorController>() != null){
            motorController = KendaraanSpawnCurrent.GetComponent<MotorController>();
        } else {
            motorController = null;
        }
    }

    public void VisualUpdate(){
        if(motorController != null){
            UIValueBensin.transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = motorController.BensinValueMax / 1800;
            UIValueBensin.transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = motorController.BensinValueMin / 1800;

            UIValueKondisi.transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = motorController.KondisiKendaraanValueMax / 1400;
            UIValueKondisi.transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = motorController.KondisiKendaraanValueMin / 1400;

            UIValueMuatan.transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = motorController.gameObject.GetComponentInChildren<Trunk>().beratBarang / 150;
            UIValueMuatan.transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = motorController.gameObject.GetComponentInChildren<Trunk>().beratBarangMin / 150;
        } else {
            UIValueBensin.transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = mobilController.BensinValueMax / 1800;
            UIValueBensin.transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = mobilController.BensinValueMin / 1800;

            UIValueKondisi.transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = mobilController.KondisiKendaraanValueMax / 1400;
            UIValueKondisi.transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = mobilController.KondisiKendaraanValueMin / 1400;

            UIValueMuatan.transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = mobilController.gameObject.GetComponentInChildren<Trunk>().beratBarang / 150;
            UIValueMuatan.transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = mobilController.gameObject.GetComponentInChildren<Trunk>().beratBarangMin / 150;
        }
    }

    public void UnlockKendaraan(){

        if(UIDuitScript.instance.JumlahUang >= KendaraanHarga[IndexKendaraan]){

            Destroy(KendaraanSpawnCurrent);
            KendaraanSpawnCurrent = Instantiate(Kendaraan[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);
            KendaraanSpawn = Kendaraan[IndexKendaraan];
            GameManager.Instance.UnlockKendaraan[IndexKendaraan] = true;
            BeliButton.SetActive(false);

            Harga.text = null;

            UIDuitScript.instance.JumlahUang -= KendaraanHarga[IndexKendaraan];
        }
       
    }
}
