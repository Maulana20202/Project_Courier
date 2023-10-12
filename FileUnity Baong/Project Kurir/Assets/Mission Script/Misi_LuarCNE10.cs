using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misi_LuarCNE10 : MissionScriptBase
{
    
    void Awake(){
       JumlahMison = Box.Count; 
    }
    public void OnEnable(){
        MissionSpawn();
        
        JumlahMisi.instance.jumlahMission = JumlahMison;
 
        JumlahMisi.instance.JumlahMisiCurrent = JumlahMison;
    }
}
