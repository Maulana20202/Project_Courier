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
        
    }

    // Update is called once per frame
    void Update()
    {
        AngkaYangTerpilih = RandomAngka;
        SaveUI.MisiYangAktif = AngkaYangTerpilih;
    }


    protected override void Interact()
    {
        RandomAngka = Random.Range(0, ScriptMisi.Count);

        ScriptMisi[RandomAngka].enabled = true;
    }
}
