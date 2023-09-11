using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryContainer : MonoBehaviour
{
    public static UIInventoryContainer instance;
    public Transform ItemContent;

    public GameObject ItemInventory;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clear()
    {

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

    }
}
