using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIWaktuScript : MonoBehaviour
{
    public static UIWaktuScript Instance;
    private GameObject displayClock;

    bool display;

    public int TIMESCALE = 100;

    public TextMeshProUGUI clockText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI seasonText;
    public TextMeshProUGUI yearText;
    public GameObject siang;
    public GameObject malam;

    public float minute, hour, day, second, month, year;

    // Start is called before the first frame update


    void Awake(){

        Instance = this;
            month = 1;
            day = 1;
            year = 2021;
            hour = 5;
            minute = 0;
    }
    void Start()
    {
        TextCallFunction();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTime();
        CalculateSeason();
    }

     void TextCallFunction()
    {
        dayText.text = "Day: " + day;
        clockText.text = string.Format("{0:00} : {1:00}", hour, minute);
        yearText.text = "Year: " + year;
    }

    void CalculateSeason()
    {
        if (month == 1)
        {
            seasonText.text = "Januari";
        }
        if (month == 2)
        {
            seasonText.text = "Februari";
        }
        if (month == 3)
        {
            seasonText.text = "Maret";
        }
        if (month == 4)
        {
            seasonText.text = "April";
        }
        if (month == 5)
        {
            seasonText.text = "Mai";
        }
        if (month == 6)
        {
            seasonText.text = "Juni";
        }
        if (month == 7)
        {
            seasonText.text = "Juli";
        }
        if (month == 8)
        {
            seasonText.text = "Agustus";
        }
        if (month == 9)
        {
            seasonText.text = "September";
        }
        if (month == 10)
        {
            seasonText.text = "Oktober";
        }
        if (month == 11)
        {
            seasonText.text = "November";
        }
        if (month == 12)
        {
            seasonText.text = "Desember";
        }
    }

    void CalculateMonth()
    {
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day >= 32)
            {
                month++;
                day = 1;
                TextCallFunction();
                CalculateSeason();
            }
        }

        if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            if (day >= 31)
            {
                month++;
                day = 1;
                TextCallFunction();
                CalculateSeason();
            }
        }

        if (month == 2)
        {
            month++;
            day = 1;
            TextCallFunction();
            CalculateSeason();
        }
    }

    void CalculateTime()
    {
        second += Time.deltaTime * TIMESCALE;

        if (second >= 60)
        {
            minute += 1;
            second = 0;
            TextCallFunction();
        }
        else if (minute >= 60)
        {
            hour++;
            minute = 0;
            TextCallFunction();
        }
        else if (hour >= 24)
        {
            day++;
            hour = 0;
            TextCallFunction();
            
        }
        else if (day >= 28)
        {
            CalculateMonth();
        }
        else if (month > 12)
        {
            month = 1;
            year++;
            TextCallFunction();
            CalculateSeason();
        }
    }
}
