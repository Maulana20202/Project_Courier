using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMobil : MonoBehaviour
{
    public GameObject Player;

    public float Jarak;

    public float MaxDistance;

    public List<GameObject> DaftarNPC = new List<GameObject>();

    public bool Already_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("PlayerUtama");
        MaxDistance = 80f;
    }

    // Update is called once per frame
    void Update()
    {

        Jarak = Vector3.Distance(this.gameObject.transform.position,Player.transform.position);

        if(Vector3.Distance(this.gameObject.transform.position,Player.transform.position) < MaxDistance && Already_Spawn == false){
            int RandomAngka = Random.Range(0, DaftarNPC.Count);

            GameObject SpawnNpc = Instantiate(DaftarNPC[RandomAngka], this.gameObject.transform.position, this.gameObject.transform.rotation);

            SpawnNpc.GetComponent<Mobil_Script>().Player = Player;

            SpawnNpc.GetComponent<Mobil_Script>().spawnerMobil = this;

            SpawnNpc.GetComponent<Mobil_Script>().waypoint = this.GetComponent<WaypointAja>();

            Already_Spawn = true;

            
        }   
    }
}
