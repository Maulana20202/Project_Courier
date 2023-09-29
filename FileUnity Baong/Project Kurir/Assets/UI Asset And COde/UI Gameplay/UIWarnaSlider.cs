using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[ExecuteAlways]
public class UIWarnaSlider : MonoBehaviour
{

    [SerializeField] private Gradient WarnaSlider;

    public GameObject SliderLaper;

    public GameObject SliderBensin;

    public GameObject SliderStamina;

    public GameObject SliderKerusakan;

    public Slider SliderLaperValue;

    public Slider SliderBensinValue;

    public Slider SliderStaminaValue;

    public Slider SliderKerusakanValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderLaper.GetComponent<Image>().color = WarnaSlider.Evaluate(SliderLaperValue.value/100f);

        SliderStamina.GetComponent<Image>().color = WarnaSlider.Evaluate(SliderStaminaValue.value/100f);

        SliderBensin.GetComponent<Image>().color = WarnaSlider.Evaluate(SliderBensinValue.value/100f);

        SliderKerusakan.GetComponent<Image>().color = WarnaSlider.Evaluate(SliderKerusakanValue.value/100f);
    }
}
