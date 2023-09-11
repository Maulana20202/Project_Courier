using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkController : MonoBehaviour
{

    public BoxStats boxstats;

    [SerializeField]
    public float nyawaBarang;

    public BoxStatsContainer boxstatsContainer;

    public TrunkManager trunkManager;

    // Start is called before the first frame update

    // Update is called once per frame

    public void Start()
    {
        boxstatsContainer = FindAnyObjectByType<BoxStatsContainer>();
        trunkManager = GameObject.FindGameObjectWithTag("MainTrunk").GetComponent<TrunkManager>();
    }
    public void PickUpItem()
    {
        boxstatsContainer.PickUpBox(boxstats, nyawaBarang);
        trunkManager.Remove(boxstats,nyawaBarang);

        UIInventoryContainer.instance.Clear();
        Destroy(gameObject);

    }


    public void AddItem(BoxStats newboxstats, float NyawaBarang)
    {
        boxstats = newboxstats;

        nyawaBarang = NyawaBarang;
    }
}
