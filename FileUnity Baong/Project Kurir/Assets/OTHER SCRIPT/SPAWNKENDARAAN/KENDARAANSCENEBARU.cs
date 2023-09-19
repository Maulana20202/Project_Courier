using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class KENDARAANSCENEBARU : MonoBehaviour
{

    public GameObject PlayerUtama;
    public SaveUIValue SaveUI;

    public Transform PosisiSpawn;



    
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player;

        GameObject Kendaraan;

        Motor motor;

        Player = PlayerUtama.transform.GetChild(0).gameObject;

        PosisiSpawn = this.transform;
        if(SaveUI.KendaraanYangDigunakan != null){
            Kendaraan = Instantiate(SaveUI.KendaraanYangDigunakan, PosisiSpawn.position, quaternion.identity);
            motor = Kendaraan.GetComponentInChildren<Motor>();

            motor.NaikMotorStart();
            Player.transform.SetParent(Kendaraan.transform);
            Player.SetActive(false);
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
