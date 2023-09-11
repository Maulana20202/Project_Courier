using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance; 

    // Var Stats Perut
    public float StatsPerut;
    public float MaxStatsPerut;

    // Var Stats Stamina
    public float StatsStamina;
    public float MaxStatsStamina;

    // Var Stats Bar
    public Slider StatsPerutSlider;
    public Slider StatsStaminaSlider;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        StatsPerutSlider.value = StatsPerut;

        StatsStaminaSlider.value = StatsStamina;


        StatsStamina = PlayerMovement.instance.StatsStamina;
        StatsPerut = PlayerMovement.instance.StatsPerut;
    }
}
