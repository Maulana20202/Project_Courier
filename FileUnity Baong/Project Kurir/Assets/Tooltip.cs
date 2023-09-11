using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BoxStats boxstats;
    public TrunkController trunkController;
    public float NyawaBarang;

    private void Update()
    {
        boxstats = trunkController.boxstats;
        NyawaBarang = trunkController.nyawaBarang;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            TooltipManager.instance.MunculinToolTip(boxstats.NamaBox, boxstats.Deskripsi, NyawaBarang.ToString(), boxstats.GambarBarang);
            Debug.Log("Enter");
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.instance.HideToolTip();
        Debug.Log("Exit");
    }
}
