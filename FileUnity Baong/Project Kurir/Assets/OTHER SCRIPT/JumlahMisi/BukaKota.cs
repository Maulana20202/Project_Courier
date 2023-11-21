using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukaKota : MonoBehaviour
{

    public GameObject BukaKota2;

    public GameObject BukaKota3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.KotaUnlock[2]==true){
            BukaKota2.SetActive(false);
        }
         if(GameManager.Instance.KotaUnlock[3]==true){
            BukaKota3.SetActive(false);
        }
    }
}
