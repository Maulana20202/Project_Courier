using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misi_1 : MonoBehaviour
{

     public List<GameObject> Box = new List<GameObject>();

    //Referensi Posisi Spawn Box

    public Transform posisiSpawn;

    //Referensi Wall Spawn Box

    public GameObject SpawnBoxWall;

    public AmbilMisi ambilMisi;
    // Start is called before the first frame update
    void Start()
    {
        ambilMisi = FindAnyObjectByType<AmbilMisi>();
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

        for(int i = 0; i < Box.Count;i++){
            GameObject box;
            box = Instantiate(Box[i],posisiSpawn.position,Quaternion.identity);
        }

        

        yield return new WaitForSeconds (2f);

        SpawnBoxWall.SetActive(false);
    }
}
