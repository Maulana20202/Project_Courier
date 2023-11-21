using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuNyala : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UIWaktuScript.Instance.hour >= 18 && UIWaktuScript.Instance.hour <= 24 || UIWaktuScript.Instance.hour >= 0 && UIWaktuScript.Instance.hour <= 4){
            transform.GetChild(0).gameObject.SetActive(true);
        } else {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
