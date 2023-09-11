using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GarasiScript : MonoBehaviour
{
    public List<GameObject> Kendaraan = new List<GameObject>();

    public SaveUIValue SaveUI;

    public int IndexKendaraan;

    public Transform SpawnTitik;

    public GameObject KendaraanSpawnCurrent;

    public GameObject KendaraanSpawn;


    //Reference Cam

    public GameObject camBagasi;

    public GameObject camPlayer;

    public GameObject UIGameplay;

    public GameObject UIGarasi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Update(){

        SaveUI.KendaraanYangDigunakan = KendaraanSpawn;

    }
    

    public void InstantiateKendaraanNambah(){

        Destroy(KendaraanSpawnCurrent);

        IndexKendaraan += 1;

        KendaraanSpawnCurrent = Instantiate(Kendaraan[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);

        KendaraanSpawn = Kendaraan[IndexKendaraan];
    }


    public void InstantiateKendaraanKurang(){

        Destroy(KendaraanSpawnCurrent);

        IndexKendaraan -= 1;

        KendaraanSpawnCurrent = Instantiate(Kendaraan[IndexKendaraan], SpawnTitik.position, SpawnTitik.rotation);

        KendaraanSpawn = Kendaraan[IndexKendaraan];
    }


    public void Konfirmasi(){

        camBagasi.SetActive(false);
        camPlayer.SetActive(true);

        UIGameplay.SetActive(true);
        UIGarasi.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
