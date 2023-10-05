using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerTerlambat : MonoBehaviour
{

    public SaveUntukJamPulang SaveanJam;

    public bool Terlambat;

    // Start is called before the first frame update
    void Start()
    {
        Terlambat = SaveanJam.Telat;
        
        if(Terlambat == true){
            UIWaktuScript.Instance.hour = 8;
            Terlambat = false;
            SaveanJam.Telat = false;
        } else {
            UIWaktuScript.Instance.hour = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
