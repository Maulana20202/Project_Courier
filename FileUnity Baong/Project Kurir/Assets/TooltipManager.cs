using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TooltipManager : MonoBehaviour
{

    public static TooltipManager instance;

    public GameObject ToolTipBox;
    public Image GambarBarang;
    public TextMeshProUGUI NamaBarang;
    public TextMeshProUGUI Deskripsi;
    public TextMeshProUGUI NyawaBarang;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        this.gameObject.SetActive(false);
        ToolTipBox = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void MunculinToolTip(float Nyawabarang, BoxStats boxStats)
    {
        this.gameObject.SetActive(true);

            GambarBarang.sprite = boxStats.GambarBarangToolTip;   

            if(Nyawabarang >= 75){
                NamaBarang.text = "Sempurna";
                NamaBarang.faceColor = new Color (4, 140, 7, 255);
            } else if(Nyawabarang >= 50 && Nyawabarang < 75){
                NamaBarang.text = "Bagus";
                NamaBarang.faceColor = new Color (133, 185, 2, 255);
            } else if(Nyawabarang >= 25 && Nyawabarang < 50){
                NamaBarang.text = "Rusak";
                NamaBarang.faceColor = new Color (255, 144, 3, 255);
            } else if(Nyawabarang < 25){
                NamaBarang.text = "Rusak Sekali";
                NamaBarang.faceColor = new Color (254, 0, 1, 255);
            }


    }

    public void HideToolTip()
    {
        this.gameObject.SetActive(false);
    }
}
