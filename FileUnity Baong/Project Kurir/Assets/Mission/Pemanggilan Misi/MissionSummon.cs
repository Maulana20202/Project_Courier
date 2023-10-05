using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSummon : MonoBehaviour
{
    public List<MonoBehaviour> Misi = new List<MonoBehaviour>();

    public SaveUIValue SaveUI;

    

    public int MisiAktif;
    void Start()
    {
        MisiAktif = SaveUI.MisiYangAktif;
    }

    // Update is called once per frame
    void Update()
    {
        if(MisiAktif != 0){
            Misi[MisiAktif].enabled = true;
        }

        if(MisiAktif == 0){
            SaveUI.MisiYangAktif = MisiAktif;
        }
        
    }
}
