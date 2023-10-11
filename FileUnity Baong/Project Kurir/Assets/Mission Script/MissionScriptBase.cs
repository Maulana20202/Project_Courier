using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScriptBase : MonoBehaviour
{

    public List<BoxStats> Box = new List<BoxStats>();

    public List<GameObject> Penerima = new List<GameObject>();

    public List<Transform> Lokasi_Penerima = new List<Transform>();

    public int JumlahMison;
    // Start is called before the first frame update
    

    public void MissionSpawn(){
        for(int i = 0; i < Box.Count; i++){

            GameObject PenerimaObject = Instantiate(Penerima[i], Lokasi_Penerima[i].position, Quaternion.identity);

            PenerimaObject.GetComponent<PenerimaBox>().box = Box[i];

            PenerimaObject.GetComponent<PenerimaBox>().promptMessage = Box[i].NamaBox;
        }

        
    }
}
