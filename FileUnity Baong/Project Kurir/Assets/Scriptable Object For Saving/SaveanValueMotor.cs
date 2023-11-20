using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SaveanValueMotor : ScriptableObject
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
}
