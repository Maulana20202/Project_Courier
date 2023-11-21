using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuMerah : MonoBehaviour
{

    public List<GameObject> lampuMerah = new List<GameObject>();

    public float LampuMerahCount;

    public float LampuMerahCountCurrent;

    public int LampuMenyala;

    void Start(){
        LampuMerahCount = 60f;
        LampuMerahCountCurrent = LampuMerahCount;
    }
    void Update()
    {
        if(LampuMerahCountCurrent <= 0){
            for(int i = 0; i < lampuMerah.Count; i++){
                lampuMerah[i].SetActive(true);
            }

            lampuMerah[LampuMenyala].SetActive(false);

            if(LampuMenyala == lampuMerah.Count -1){
                LampuMenyala = 0;
            } else {
                LampuMenyala++;
            }

            

            LampuMerahCountCurrent = LampuMerahCount;
        } else {
            LampuMerahCountCurrent -= Time.deltaTime;
        }
    }
}
