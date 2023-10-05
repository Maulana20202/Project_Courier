using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbilMisi : interactable
{

    public List<MonoBehaviour> ScriptMisi = new List<MonoBehaviour>(); 

    public int AngkaYangTerpilih;

    public int RandomAngka;

    public SaveUIValue SaveUI;

    // Start is called before the first frame update
    void Start()
    {
        AngkaYangTerpilih = SaveUI.MisiYangAktif;
    }

    // Update is called once per frame
    void Update()
    {
        AngkaYangTerpilih = RandomAngka;
        SaveUI.MisiYangAktif = AngkaYangTerpilih;
    }


    protected override void Interact()
    {
        if(AngkaYangTerpilih == 0){
            
            RandomAngka = Random.Range(1, ScriptMisi.Count);

            ScriptMisi[RandomAngka].enabled = true;
        } else {
            Debug.Log("Gabisa Dah Milih");
        }
       
    }
}
