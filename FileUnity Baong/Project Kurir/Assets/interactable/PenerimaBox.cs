using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PenerimaBox : interactable
{

    public BoxStats box;

    public List<GameObject> Penerima = new List<GameObject>();

    public Transform TempatSpawn;

    public SpriteRenderer Icon;

    // Start is called before the first frame update
    void Start()
    {
        int RandomAngka = Random.Range(0,Penerima.Count);
        GameObject Kukingkang = Instantiate(Penerima[RandomAngka], TempatSpawn.position, TempatSpawn.rotation);
        Atasan.GetComponent<SpriteRenderer>().sprite = box.GambarBarang;
        Icon.sprite = box.GambarIconMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void InteractAlter()
    {
        if (BoxStatsContainer.Instance.boxStatus.id == box.id)
        {
            

            if (BoxStatsContainer.Instance.nyawaBarang >= 100)
            {
                UIDuitScript.instance.JumlahUang += 20000f;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;
                

            }
            else if(BoxStatsContainer.Instance.nyawaBarang >= 75)
            {
                UIDuitScript.instance.JumlahUang += 17000f;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            } 
            else if (BoxStatsContainer.Instance.nyawaBarang >= 50)
            {
                UIDuitScript.instance.JumlahUang += 15000f;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            else if (BoxStatsContainer.Instance.nyawaBarang >= 25)
            {
                UIDuitScript.instance.JumlahUang += 10000f;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            else if (BoxStatsContainer.Instance.nyawaBarang >= 0)
            {
                UIDuitScript.instance.JumlahUang += 0f;
               JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            Destroy(BoxStatsContainer.Instance.boxStatsObject);

            
        }
    }
}
