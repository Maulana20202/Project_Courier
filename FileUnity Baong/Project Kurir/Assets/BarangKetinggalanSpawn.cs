using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarangKetinggalanSpawn : MonoBehaviour
{

    private AmbilMisi ambilMisi;

    private Transform TempatSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        ambilMisi = FindAnyObjectByType<AmbilMisi>();
        TempatSpawn = this.transform;
    }

    void Start(){
        if(BarangKetinggalan.Instance.SpawnKetinggalan == true){
            for(int i = 0; i < BarangKetinggalan.Instance.barangKetinggalan.Count ;i++){
                GameObject box = Instantiate(BarangKetinggalan.Instance.barangKetinggalan[i],TempatSpawn.position,TempatSpawn.rotation);
            }
            
        }

        Debug.Log("Ini Jalan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
