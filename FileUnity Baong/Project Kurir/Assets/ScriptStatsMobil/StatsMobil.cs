using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMobil : MonoBehaviour
{

    public float StatsBensin;

    public float StatsKesehatanMobil;

    public float MaxStatsKesehatanMobil;

    public float MaxStatsBensin;


    public Slider SliderBensin;

    public Slider SliderKesehatanMobil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderBensin.value = StatsBensin;

        SliderKesehatanMobil.value = StatsKesehatanMobil;
    }
}
