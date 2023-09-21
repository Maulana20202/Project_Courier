using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class StatsSupra : StatsKendaraan
{

    public MotorController motorStats;

    public Trunk BagasiMotor;

    // Update is called once per frame

    void Start(){
        BagasiMotor = this.gameObject.GetComponentInChildren<Trunk>();
    }

    protected override void UpgradingBensin(){
        if(StatsBensin < 4){
            motorStats.BensinValueMax += motorStats.BensinValueMin * 0.25f;
            StatsBensin += 1;
        }
        
    }

    protected override void UpgradingKondisi(){

        if (StatsKondisi < 4){
             motorStats.KondisiKendaraanValueMax += motorStats.KondisiKendaraanValueMin * 0.25f;
            StatsKondisi += 1;
        }
       
    }

    protected override void UpgradingMuatan(){

        if(StatsMuatan < 4){
            BagasiMotor.beratBarang += BagasiMotor.beratBarang * 0.25f;
            StatsMuatan += 1;
        }
        
    }

    protected override void MengisiBensin(){
        if(motorStats.BensinValue < motorStats.BensinValueMax){
            motorStats.BensinValue = motorStats.BensinValueMax;
        }
    }
}
