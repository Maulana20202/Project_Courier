using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumlahMisi : MonoBehaviour
{

    public static JumlahMisi instance;

    public int jumlahMission;

    public int JumlahMisiCurrent;

    public string jumlahMissionText;

    public string JumlahMisiCurrentText;

    public TextMeshProUGUI TextJumlahMisiCurrent;

    public TextMeshProUGUI TextJumlahMission;

    public MissionSummon misiSummon;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        jumlahMissionText = jumlahMission.ToString();
        JumlahMisiCurrentText = JumlahMisiCurrent.ToString();

        TextJumlahMisiCurrent.text = JumlahMisiCurrentText;
        TextJumlahMission.text = jumlahMissionText;

    if(misiSummon.MisiAktif != 0){
        if(JumlahMisiCurrent <= 0){
            misiSummon.Misi[misiSummon.MisiAktif].enabled = false;
            misiSummon.MisiAktif = 0;
            BarangKetinggalan.Instance.SpawnKetinggalan = false;
        }
    }
        
     }
}
