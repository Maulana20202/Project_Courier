using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    public int JumlahJasHujan;

    public bool MemakaiJasHujan;

    public TextMeshProUGUI TextJumlahJasHujan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextJumlahJasHujan.text = JumlahJasHujan.ToString();
    }

    public void PakaiJasHujan(){
        if(JumlahJasHujan > 0){
             MemakaiJasHujan = true;
            JumlahJasHujan -= 1;
        }
       
    }
}
