using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWaktuText : MonoBehaviour
{

    public TextMeshProUGUI Day;
    public TextMeshProUGUI Month;
    public TextMeshProUGUI Year;
    public TextMeshProUGUI Clock;

    // Start is called before the first frame update
    void Awake()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        UIWaktuScript.Instance.dayText = Day;

        UIWaktuScript.Instance.seasonText = Month;

        UIWaktuScript.Instance.yearText = Year;

        UIWaktuScript.Instance.clockText = Clock;
    }
}
