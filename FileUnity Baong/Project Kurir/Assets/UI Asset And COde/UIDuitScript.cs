using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Globalization;
using System.IO;

public class UIDuitScript : MonoBehaviour
{

    public static UIDuitScript instance;

    public float JumlahUang;


    public SaveUIValue SaveUI;

    public TextMeshProUGUI TextUang;

    public string JumlahUangText;
    // Start is called before the first frame update
    public void Start(){
        if(instance == null){
            instance = this;
        }
        
        JumlahUang = SaveUI.JumlahUang;
    }
    // Update is called once per frame
    void Update()
    {
        JumlahUangText = JumlahUang.ToString();
        TextUang.text = string.Format(CultureInfo.CreateSpecificCulture ("id-id"), "Rp {0:N0}", JumlahUang);;
        SaveUI.JumlahUang = JumlahUang;
        
    }
}
