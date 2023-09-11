using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatsContainer : MonoBehaviour
{

    public static BoxStatsContainer Instance;

    public BoxStats boxStatus;
    public GameObject boxStatsObject;
    public float nyawaBarang;

    public Transform titikBarang;

    public PlayerMovement playerMovement;
    public PlayerCameraRotation playerCameraRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();
    }

    // Update is called once per frame

    public void AddBoxStats(BoxStats boxstats, GameObject boxstatsobject, float NyawaBarang)
    {
        boxStatus = boxstats;
        nyawaBarang = NyawaBarang;
        boxStatsObject = boxstatsobject;
    }

    public void RemoveBoxStats()
    {
        boxStatus = null;
        nyawaBarang = 0;
        boxStatsObject = null;
    }

    public void PickUpBox(BoxStats boxStats, float NyawaBarang)
    {
        GameObject obj = Instantiate(boxStats.prefabsBox, titikBarang);
        obj.transform.position = titikBarang.transform.position;
        obj.GetComponent<BoxCollider>().enabled = false;
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        obj.GetComponent<Rigidbody>().useGravity = false;
        TooltipManager.instance.ToolTipBox.SetActive(false);
        InventoryController.Instance.Inventory.SetActive(false);
        playerMovement.enabled = true;
        playerCameraRotation.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        var boxStatuss = obj.GetComponent<Box>();
        boxStatsObject = obj;
        boxStatus = boxStatuss.boxStats;
        nyawaBarang = boxStats.nyawaBarang;
        boxStatuss.Diambil = true;


    }
}
