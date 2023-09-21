using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{

    public GameObject UIStamina;
    public GameObject UIBensin;

    public GameObject UIKondisi;

    public Slider UIBensinSlider;

    public Slider UIKondisiSlider;

    // Start is called before the first frame update
    public void WalkingUI(){
        UIStamina.SetActive(true);
        UIKondisi.SetActive(false);
        UIBensin.SetActive(false);
    }

    public void RidingUI(){
        UIBensin.SetActive(true);
        UIKondisi.SetActive(true);
        UIStamina.SetActive(false);
    }
}
