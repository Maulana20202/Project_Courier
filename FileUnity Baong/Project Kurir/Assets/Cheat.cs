using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p")){
            UIDuitScript.instance.JumlahUang = 1000000000000;
        }

        if(Input.GetKeyDown("l")){
            HujanTrigger.Instance.HujanMulai = true;
        }

        if(Input.GetKeyDown("o")){
            HujanTrigger.Instance.HujanMulai = false;
        }
    }
}
