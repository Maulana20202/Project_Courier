using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsKendaraan : MonoBehaviour
{

    public int StatsBensin;

    public int StatsKondisi;

    public int StatsMuatan;

    public bool UpgradeBensin;

    public bool UpgradeKondisi;

    public bool UpgradeMuatan;

    public float SelisihBensin;

    public float HargaBensin = 10000f;
    // Start is called before the first frame update
    public void BaseUpgradingBensin(){
        UpgradingBensin();
    }

    public void BaseUpgradingKondisi(){
        UpgradingKondisi();
    }

    public void BaseUpgradingMuatan(){
        UpgradingMuatan();
    }

    public void BaseMengisiBensin(){
        MengisiBensin();
    }

    protected virtual void UpgradingBensin(){

    }

    protected virtual void UpgradingKondisi(){

    }

    protected virtual void UpgradingMuatan(){

    }

    protected virtual void MengisiBensin(){

    }
}
