using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrunkManager : MonoBehaviour
{

    public static TrunkManager Instance;
    public List<BoxStats> Items = new List<BoxStats> ();
    public List<float> nyawaBarang = new List<float> ();

    public SaveanPercobaan saveanList;

    public Transform ItemContent;
    public GameObject InventoryItem;

    public UIInventoryContainer InventoryContainer;

    public TrunkController[] trunkControllers;
    // Start is called before the first frame update
    public void Awake()
    {
        InventoryContainer = FindAnyObjectByType<UIInventoryContainer>();

        ItemContent = InventoryContainer.ItemContent;
        InventoryItem = InventoryContainer.ItemInventory;
    }

    public void Start()
    {
        if(saveanList.ListBagasi != null){
            Items = saveanList.ListBagasi;
        }

        if(saveanList.ListNyawaBarang != null){
            nyawaBarang = saveanList.ListNyawaBarang;
        }

    }


    public void Update(){
        if (Items != null){
            saveanList.ListBagasi = Items;
            saveanList.ListNyawaBarang = nyawaBarang;
        }
        
    }

    // Update is called once per frame
    public void Add(BoxStats boxStats, float NyawaBarang)
    {
        Items.Add(boxStats);
        nyawaBarang.Add(NyawaBarang);
    }

    public void Remove(BoxStats boxStats, float NyawaBarang)
    {
        Items.Remove(boxStats);
        nyawaBarang.Remove(NyawaBarang);
    }

    public void ForDestroy(GameObject boxObject)
    {
        Destroy(boxObject);
        
    }

    public void listItem()
    {
        
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

   

        foreach (var boxStats in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var ItemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var ItemIcon = obj.transform.Find("ItemImage").GetComponent<Image>();

            ItemName.text = boxStats.NamaBox.ToString();
            ItemIcon.sprite = boxStats.GambarBarang;
        }

        SetTrunkController();



        Debug.Log("Kepencet");
    }

    public void SetTrunkController()
    {
        trunkControllers = ItemContent.GetComponentsInChildren<TrunkController>();

        for (int i = 0; i < Items.Count; i++) {

            trunkControllers[i].AddItem(Items[i], nyawaBarang[i]);
        }
    }

    

    public void MinusNyawa()
    {
        for(int i = 0; i < nyawaBarang.Count ; i++){

            switch (Items[i].jenis){
                case BoxStats.JenisBarang.Fragile:
                    nyawaBarang[i] -= 10f;
                break;
                case BoxStats.JenisBarang.Non_Fragile:
                    nyawaBarang[i] -= 5f;
                break;
            }

        }
    }



}
