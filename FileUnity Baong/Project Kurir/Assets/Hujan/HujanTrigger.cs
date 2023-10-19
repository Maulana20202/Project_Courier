using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class HujanTrigger : MonoBehaviour
{

    public static HujanTrigger Instance;
    public Material cloud;

    public GameObject Hujan;

    public bool HujanMulai;

    public GameObject DirectionalColor;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(HujanMulai == true){
            Hujan.SetActive(true);
            DirectionalColor.SetActive(false);
        } else {
            Hujan.SetActive(false);
            DirectionalColor.SetActive(true);
        }
    }
}
