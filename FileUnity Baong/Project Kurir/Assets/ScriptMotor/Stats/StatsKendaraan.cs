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

    public Sprite GambarKendaraan;

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
    public void BaseMengisiKondisi(){
        MengisiKondisi();
    }

    protected virtual void UpgradingBensin(){

    }

    protected virtual void UpgradingKondisi(){

    }

    protected virtual void UpgradingMuatan(){

    }

    protected virtual void MengisiBensin(){

    }

    protected virtual void MengisiKondisi(){

    }
}
