using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBensin : interactable
{
    // Start is called before the first frame update
    protected override void Interact(){
        UpgradingSystem.instance.IsiBensin();
    }
}
