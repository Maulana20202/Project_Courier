using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Misi_2_LuarCne : MonoBehaviour
{
    public List<BoxStats> box = new List<BoxStats>();
    
    //Prefabs Penerima

    public List<GameObject> Penerima = new List<GameObject>();


    //Transform Lokasi
    public List<Transform> Lokasi_Penerima = new List<Transform>();

    public List<GameObject> PenerimaSpawn = new List<GameObject>();
    //Jumlah Misi Yang Ada dan yang tersisa

    public int JumlahMison;

    public int JumlahMisiCurrent;
    
    public void Start(){

    }


    public void OnEnable(){

        for(int i = 0; i<box.Count; i++){
             GameObject penerima = Instantiate(Penerima[i], Lokasi_Penerima[i].position, Lokasi_Penerima[i].rotation,  Lokasi_Penerima[i]);

            penerima.GetComponent<PenerimaBox>().box = box[i];

            PenerimaSpawn.Add(penerima);

        }

        JumlahMisi.instance.jumlahMission = JumlahMison;

        JumlahMisi.instance.JumlahMisiCurrent = JumlahMison;

    }


    void OnDisable (){
        
        for(int i = 0 ; i < PenerimaSpawn.Count ; i++){
            Destroy(PenerimaSpawn[i]);
        }

        PenerimaSpawn = null;

    }

}
