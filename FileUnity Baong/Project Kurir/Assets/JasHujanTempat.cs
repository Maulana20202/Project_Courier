using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasHujanTempat : MonoBehaviour
{

    public static JasHujanTempat instance;
    public int JasHujan;

    public bool PakeJasHujan;

    public float CountDown;

    public float CountDownCurrent;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
             
            Destroy(gameObject);
        
        }

        CountDown = 43200;
        CountDownCurrent = CountDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(PakeJasHujan == true){
            if(CountDownCurrent <= 0){
                PakeJasHujan = false;
                CountDownCurrent = CountDown;
            }
        }
    }
}
