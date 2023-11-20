using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    
    public static List<SaveanValueMotor> SaveMotor = new List<SaveanValueMotor>();

    public SaveUIValue saveUI;

    public GameManager gameManager;

    const string MOTOR_KEY = "/motor";

    const string DUIT_KEY = "/DUIT";

    const string KOTA_KEY = "/KOTA";

    const string DAY_KEY = "/DAY";

    void Save()
    {

        string key = MOTOR_KEY;

        string Duitkey = DUIT_KEY;

        string KotaKey = KOTA_KEY;

        DuitData dataDuit = new DuitData(saveUI);

        SaveSystem.save(dataDuit, Duitkey);

        SaveSystem.save(gameManager, KotaKey);

        for(int i = 0; i < SaveMotor.Count ; i++){

            MotorData dataMotor = new MotorData(SaveMotor[i]);

            SaveSystem.save(dataMotor, key + i);
        }
    }

    // Update is called once per frame
    void Load()
    {
        string key = MOTOR_KEY;

        string Duitkey = DUIT_KEY;

        string KotaKey = KOTA_KEY;

        for(int i = 0; i < SaveMotor.Count ; i++){

            SaveSystem.Load<MotorData>(key + i);

            
        }

        SaveSystem.Load<DuitData>(Duitkey);

        SaveSystem.Load<DuitData>(Duitkey);
    }
}
