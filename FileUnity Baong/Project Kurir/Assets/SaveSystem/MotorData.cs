
using UnityEngine;

[System.Serializable]
public class MotorData
{
    public float BensinValueMax;
    public float MuatanValueMax;
    public float KondisiValueMax;

    public float HargaBensin;

    public float HargaKondisi;

    public float HargaMuatan;

    public int UpgradeBensinValue;

    public int UpgradeKondisiValue;

    public int UpgradeMuatanValue;

    public float BensinCurrent;

    public float KondisiCurrent;

    public MotorData(SaveanValueMotor SaveMotor){
        BensinValueMax = SaveMotor.BensinValueMax;
        MuatanValueMax = SaveMotor.MuatanValueMax;
        KondisiValueMax = SaveMotor.KondisiValueMax;

        HargaBensin = SaveMotor.HargaBensin;
        HargaKondisi = SaveMotor.HargaKondisi;
        HargaMuatan = SaveMotor.HargaMuatan;

        UpgradeBensinValue = SaveMotor.UpgradeBensinValue;
        UpgradeKondisiValue = SaveMotor.UpgradeKondisiValue;
        UpgradeMuatanValue = SaveMotor.UpgradeMuatanValue;

        BensinCurrent = SaveMotor.BensinCurrent;
        KondisiCurrent = SaveMotor.KondisiCurrent;
    }
}
