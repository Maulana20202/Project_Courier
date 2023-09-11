using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misi_0 : MonoBehaviour
{

    //Referensi Box
    public GameObject Box_1;
    public GameObject Box_2;
    public GameObject Box_3;
    public GameObject Box_4;
    public GameObject Box_5;

    //Referensi Posisi Spawn Box

    public Transform posisiSpawn;

    //Referensi Wall Spawn Box

    public GameObject SpawnBoxWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnEnable(){

        StartCoroutine(DelayWallSpawn());
    }



    IEnumerator DelayWallSpawn(){


        SpawnBoxWall.SetActive(true);

        GameObject box_1;

        box_1 = Instantiate(Box_1,posisiSpawn.position,Quaternion.identity);

        GameObject box_2;

        box_2 = Instantiate(Box_2,posisiSpawn.position,Quaternion.identity);

        GameObject box_3;

        box_3 = Instantiate(Box_3,posisiSpawn.position,Quaternion.identity);


        GameObject box_4;

        box_4 = Instantiate(Box_4,posisiSpawn.position,Quaternion.identity);


        GameObject box_5;

        box_5 = Instantiate(Box_5,posisiSpawn.position,Quaternion.identity);


        yield return new WaitForSeconds (2f);

        SpawnBoxWall.SetActive(false);
    }
}
