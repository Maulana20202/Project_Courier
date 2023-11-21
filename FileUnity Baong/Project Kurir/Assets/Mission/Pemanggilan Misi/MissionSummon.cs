using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSummon : MonoBehaviour
{
    public List<MonoBehaviour> Misi = new List<MonoBehaviour>();

    public List<MonoBehaviour> Misi2 = new List<MonoBehaviour>();

    public List<MonoBehaviour> Misi3 = new List<MonoBehaviour>();

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

            if(GameManager.Instance.KotaTerpilih[1] == true){
                Misi[MisiAktif].enabled = true;
            } else if(GameManager.Instance.KotaTerpilih[2] == true){
                Misi2[MisiAktif].enabled = true;
            } else if(GameManager.Instance.KotaTerpilih[3] == true) {
                Misi3[MisiAktif].enabled = true;
            }
        }

        if(MisiAktif == 0){
            SaveUI.MisiYangAktif = MisiAktif;
        }
        
    }
}
