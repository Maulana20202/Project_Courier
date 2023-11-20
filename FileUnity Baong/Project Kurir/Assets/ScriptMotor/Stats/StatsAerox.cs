using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsAerox : StatsKendaraan
{
    public MotorController motorStats;

    public Trunk BagasiMotor;

    public float HargaUpgradeBensinMin;

    public float HargaBensinCurrent;

    public float HargaUpgradeKondisiMin;

    public float HargaKondisiCurrent;

    public float HargaUpgradeKapasitasMin;

    public float HargaKapasitasCurrent;

    public SaveanValueMotor saveanHarga;

    // Update is called once per frame

    void Start(){
        BagasiMotor = this.gameObject.GetComponentInChildren<Trunk>();

        HargaBensinCurrent = saveanHarga.HargaBensin;
        HargaKondisiCurrent = saveanHarga.HargaKondisi;
        HargaKapasitasCurrent = saveanHarga.HargaMuatan;
                StatsBensin = saveanHarga.UpgradeBensinValue;
        StatsKondisi = saveanHarga.UpgradeKondisiValue;
        StatsMuatan = saveanHarga.UpgradeMuatanValue;
    }

       protected override void UpgradingBensin(){

        if(UIDuitScript.instance.JumlahUang >= HargaBensinCurrent){
            if(StatsBensin < 4){
            motorStats.BensinValueMax += motorStats.BensinValueMin * 0.25f;
            StatsBensin += 1;
            UIDuitScript.instance.JumlahUang -= HargaBensinCurrent;
            HargaBensinCurrent += HargaUpgradeBensinMin * 0.25f;
            saveanHarga.HargaBensin = HargaBensinCurrent;
            saveanHarga.UpgradeBensinValue = StatsBensin;
            }
        }
        
        
    }

    protected override void UpgradingKondisi(){

        if(UIDuitScript.instance.JumlahUang >= HargaKondisiCurrent){
                if (StatsKondisi < 4){
                    motorStats.KondisiKendaraanValueMax += motorStats.KondisiKendaraanValueMin * 0.25f;
                    StatsKondisi += 1;
                    UIDuitScript.instance.JumlahUang -= HargaKondisiCurrent;
                    HargaKondisiCurrent += HargaUpgradeKondisiMin * 0.25f;
                    saveanHarga.HargaKondisi = HargaKondisiCurrent;
                    saveanHarga.UpgradeKondisiValue = StatsKondisi;
                }
        
        }
    }

    protected override void UpgradingMuatan(){

        if(UIDuitScript.instance.JumlahUang >= HargaKapasitasCurrent){
            if(StatsMuatan < 4){
                BagasiMotor.beratBarang += BagasiMotor.beratBarangMin * 0.25f;
                StatsMuatan += 1;
                UIDuitScript.instance.JumlahUang -= HargaKapasitasCurrent;
                HargaKapasitasCurrent += HargaUpgradeKapasitasMin * 0.25f;
                saveanHarga.HargaMuatan = HargaKapasitasCurrent;
                saveanHarga.UpgradeMuatanValue = StatsMuatan;
            }
        }
        
    }

    protected override void MengisiBensin(){
        if(motorStats.BensinValue < motorStats.BensinValueMax){

            float SelisihBensin;

            float Harga;

            SelisihBensin = motorStats.BensinValueMax - motorStats.BensinValue;

            Harga = SelisihBensin / 100 * HargaBensin;


            motorStats.BensinValue = motorStats.BensinValueMax;

            UIDuitScript.instance.JumlahUang -= Harga;
        }
    }
}
