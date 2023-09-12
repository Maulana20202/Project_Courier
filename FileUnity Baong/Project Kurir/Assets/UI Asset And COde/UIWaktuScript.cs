using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIWaktuScript : MonoBehaviour
{
    private GameObject displayClock;

    bool display;

    private const int TIMESCALE = 20;

    public TextMeshProUGUI clockText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI seasonText;
    public TextMeshProUGUI yearText;
    public GameObject siang;
    public GameObject malam;

    public static double minute, hour, day, second, month, year;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
