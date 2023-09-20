using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class KENDARAANSCENEBARU : MonoBehaviour
{

    public static KENDARAANSCENEBARU instance;
    public GameObject PlayerUtama;
    public SaveUIValue SaveUI;

    public Transform PosisiSpawn;

    public bool SpawnKendaraan;


    void Awake(){
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player;

        GameObject Kendaraan;


        Player = PlayerUtama.transform.GetChild(0).gameObject;

        PosisiSpawn = this.transform;
        if(SaveUI.KendaraanYangDigunakan != null){
            Kendaraan = Instantiate(SaveUI.KendaraanYangDigunakan, PosisiSpawn.position, quaternion.identity); 
            Player.transform.SetParent(Kendaraan.transform);
            SpawnKendaraan = true;
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
