using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuSpawn : MonoBehaviour
{

    public GameObject Player;

     public float MaxDistance;

     public float Jarak;
    // Start is called before the first frame update
    void Start()
    {
        MaxDistance = 100f;
        Player = GameObject.FindWithTag("PlayerUtama");
    }

    // Update is called once per frame
    void Update()
    {
        Jarak = Vector3.Distance(transform.position,Player.transform.position);

        if(Vector3.Distance(transform.position,Player.transform.position) < MaxDistance){
            this.transform.GetChild(0).gameObject.SetActive(true);
        } else {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
