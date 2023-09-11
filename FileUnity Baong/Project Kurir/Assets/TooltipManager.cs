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

    public void MunculinToolTip(string Namabarang, string deskripsi, string Nyawabarang, Sprite gambarBarang)
    {
        this.gameObject.SetActive(true);
        GambarBarang.sprite = gambarBarang;
        NamaBarang.text = Namabarang;
        Deskripsi.text = deskripsi;
        NyawaBarang.text = Nyawabarang;
    }

    public void HideToolTip()
    {
        this.gameObject.SetActive(false);
    }
}
