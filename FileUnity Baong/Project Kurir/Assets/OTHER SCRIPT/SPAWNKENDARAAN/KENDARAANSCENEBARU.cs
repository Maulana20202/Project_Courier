using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class KENDARAANSCENEBARU : MonoBehaviour
{


    public SaveUIValue SaveUI;

    public Transform PosisiSpawn;


    // Start is called before the first frame update
    void Start()
    {
        GameObject Kendaraan;

        PosisiSpawn = this.transform;
        if(SaveUI.KendaraanYangDigunakan != null){
            Kendaraan = Instantiate(SaveUI.KendaraanYangDigunakan, PosisiSpawn.position, quaternion.identity);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
