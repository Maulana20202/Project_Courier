using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasHujanBeli : interactable
{
    // Start is called before the first frame update
    protected override void Interact(){
        UIDuitScript.instance.JumlahUang -= 10000;
        JasHujanTempat.instance.JasHujan  += 1;
    }
        
}
