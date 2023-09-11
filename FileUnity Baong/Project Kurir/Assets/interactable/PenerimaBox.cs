using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PenerimaBox : interactable
{

    public BoxStats box;

    // Start is called before the first frame update
    void Start()
    {
        
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
                UIDuitScript.instance.JumlahUang += 20000;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;
                

            }
            else if(BoxStatsContainer.Instance.nyawaBarang >= 80)
            {
                UIDuitScript.instance.JumlahUang += 17000;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            } 
            else if (BoxStatsContainer.Instance.nyawaBarang >= 80)
            {
                UIDuitScript.instance.JumlahUang += 15000;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            else if (BoxStatsContainer.Instance.nyawaBarang >= 60)
            {
                UIDuitScript.instance.JumlahUang += 10000;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            else if (BoxStatsContainer.Instance.nyawaBarang >= 40)
            {
                UIDuitScript.instance.JumlahUang += 5000;
                JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            else if (BoxStatsContainer.Instance.nyawaBarang >= 20)
            {
                UIDuitScript.instance.JumlahUang += 0;
               JumlahMisi.instance.JumlahMisiCurrent -= 1;

            }

            Destroy(BoxStatsContainer.Instance.boxStatsObject);

            
        }
    }
}
