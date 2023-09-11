using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misi_1 : MonoBehaviour
{

    //Prefabs Penerima Paket
    [Header("Penerima Prefabs")]

    public GameObject Penerima_1;
    public GameObject Penerima_2;
    public GameObject Penerima_3;
    public GameObject Penerima_4;
    public GameObject Penerima_5;

    //GameObject Penerima_Spawn

    [Header("Penerima Variable")]

    GameObject Penerima_1_Spawn;
    GameObject Penerima_2_Spawn;
    GameObject Penerima_3_Spawn;
    GameObject Penerima_4_Spawn;
    GameObject Penerima_5_Spawn;

    [Header("GameObject Barang")]

    GameObject Barang_1;
    GameObject Barang_2;
    GameObject Barang_3;
    GameObject Barang_4;
    GameObject Barang_5;

    //Parent
    [Header("Parent Penerima")]

    public Transform ParentPenerima;

    //Parent

    [Header("Parent Barang")]

    public Transform ParentBarang;

    //Titik Spawn

    [Header("Titik Spawn")]

    public Transform titikSpawn_1;       
    public Transform titikSpawn_2;
    public Transform titikSpawn_3;
    public Transform titikSpawn_4;
    public Transform titikSpawn_5;

    //Titik Spawn Barang

    [Header("Titik Spawn")]

    public Transform titikSpawn_Barang;

    //Box Penahan

    [Header("Box Penahan")]

    public GameObject BoxPenahan;

    //Jumlah Paket

    [Header("Jumlah Paket")]

    public int jumlahPaket;


    //Waktu Spawn Penahan

    [Header("Spawn Penahan")]

    public float Waktu_Spawn_Penahan;
    public float Waktu_Spawn_Penahan_Current;

    // List Angka Random

    private List<int> RandomAngka = new List<int>();

    // BoxStats
    [Header("Box Stats")]

    public List<BoxStats> boxStats = new List<BoxStats>();

    // BoxStats

    [Header("Box Object")]
    public List<GameObject> boxObject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Waktu_Spawn_Penahan_Current <= 0)
        {
            BoxPenahan.SetActive(false);
        } else
        {
            Waktu_Spawn_Penahan_Current -= Time.deltaTime;
        }

        if(UI_Misi.Instance.jumlahPaketCurrent <= 0)
        {
            this.enabled = false;
        }

        
    }


    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        {
            int Angka = Random.Range(0, boxStats.Count);

            RandomAngka.Add(Angka);
        }

        BoxPenahan.SetActive(true);

        Waktu_Spawn_Penahan_Current = Waktu_Spawn_Penahan;

        UI_Misi.Instance.jumlahPaketCurrent = jumlahPaket;



        //Penerima Dan Barang Spawn 1

        Penerima_1_Spawn = Instantiate(Penerima_1, titikSpawn_1.position, Quaternion.identity, ParentPenerima);

        Penerima_1_Spawn.GetComponent<PenerimaBox>().box = boxStats[RandomAngka[0]];

        Penerima_1_Spawn.GetComponent<PenerimaBox>().promptMessage = boxStats[RandomAngka[0]].ToString();

        Barang_1 = Instantiate(boxObject[RandomAngka[0]], titikSpawn_Barang.position, Quaternion.identity, ParentPenerima);

        //Penerima Dan Barang Spawn 2

        Penerima_2_Spawn = Instantiate(Penerima_2, titikSpawn_2.position, Quaternion.identity, ParentPenerima);

        Penerima_2_Spawn.GetComponent<PenerimaBox>().box = boxStats[RandomAngka[1]];

        Penerima_2_Spawn.GetComponent<PenerimaBox>().promptMessage = boxStats[RandomAngka[1]].ToString();

        Barang_2 = Instantiate(boxObject[RandomAngka[1]], titikSpawn_Barang.position, Quaternion.identity, ParentPenerima);

        //Penerima Dan Barang Spawn 3

        Penerima_3_Spawn = Instantiate(Penerima_3, titikSpawn_3.position, Quaternion.identity, ParentPenerima);

        Penerima_3_Spawn.GetComponent<PenerimaBox>().box = boxStats[RandomAngka[2]];

        Penerima_3_Spawn.GetComponent<PenerimaBox>().promptMessage = boxStats[RandomAngka[2]].ToString();

        Barang_3 = Instantiate(boxObject[RandomAngka[2]], titikSpawn_Barang.position, Quaternion.identity, ParentPenerima);

        //Penerima Dan Barang Spawn 4

        Penerima_4_Spawn = Instantiate(Penerima_4, titikSpawn_4.position, Quaternion.identity, ParentPenerima);

        Penerima_4_Spawn.GetComponent<PenerimaBox>().box = boxStats[RandomAngka[3]];

        Penerima_4_Spawn.GetComponent<PenerimaBox>().promptMessage = boxStats[RandomAngka[3]].ToString();

        Barang_4 = Instantiate(boxObject[RandomAngka[3]], titikSpawn_Barang.position, Quaternion.identity, ParentPenerima);

        //Penerima Dan Barang Spawn 5

        Penerima_5_Spawn = Instantiate(Penerima_5, titikSpawn_5.position, Quaternion.identity, ParentPenerima);

        Penerima_5_Spawn.GetComponent<PenerimaBox>().box = boxStats[RandomAngka[4]];

        Penerima_5_Spawn.GetComponent<PenerimaBox>().promptMessage = boxStats[RandomAngka[4]].ToString();

        Barang_5 = Instantiate(boxObject[RandomAngka[4]], titikSpawn_Barang.position, Quaternion.identity, ParentPenerima);

        
    }

    private void OnDisable()
    {
        RandomAngka.Clear();

        boxStats.Clear();

        Destroy(Penerima_1_Spawn);
        Destroy(Penerima_2_Spawn);
        Destroy(Penerima_3_Spawn);
        Destroy(Penerima_4_Spawn);
        Destroy(Penerima_5_Spawn);
    }


}
