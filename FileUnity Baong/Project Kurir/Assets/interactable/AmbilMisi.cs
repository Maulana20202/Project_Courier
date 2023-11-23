using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbilMisi : interactable
{

    public List<MonoBehaviour> ScriptMisi = new List<MonoBehaviour>(); 

    public List<MonoBehaviour> ScriptMisi2 = new List<MonoBehaviour>(); 

    public List<MonoBehaviour> ScriptMisi3 = new List<MonoBehaviour>(); 

    public int AngkaYangTerpilih;

    public int RandomAngka;

    public SaveUIValue SaveUI;


    public Transform TempatSpawn;

    

    // Start is called before the first frame update
    void Start()
    {
        AngkaYangTerpilih = SaveUI.MisiYangAktif;
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveUI.MisiYangAktif = AngkaYangTerpilih;
    }


    protected override void Interact()
    {
        if(AngkaYangTerpilih == 0 && BarangKetinggalan.Instance.SpawnKetinggalan == false){
            
            RandomAngka = Random.Range(1, ScriptMisi.Count);
            AngkaYangTerpilih = RandomAngka;
            if(GameManager.Instance.KotaTerpilih[1] == true){
                ScriptMisi[RandomAngka].enabled = true;
                
            }

            if(GameManager.Instance.KotaTerpilih[2] == true){
                ScriptMisi2[RandomAngka].enabled = true;
            }

            if(GameManager.Instance.KotaTerpilih[3] == true){
                ScriptMisi3[RandomAngka].enabled = true;
            }
           SaveUI.MisiYangAktif = AngkaYangTerpilih;


            
        } else {
            Debug.Log("Gabisa Dah Milih");
        }
       
    }
}
