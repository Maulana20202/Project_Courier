using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpawnNPC : MonoBehaviour
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
        MaxDistance = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        Jarak = Vector3.Distance(this.gameObject.transform.position,Player.transform.position);

        if(Vector3.Distance(this.gameObject.transform.position,Player.transform.position) < MaxDistance && Already_Spawn == false){
            int RandomAngka = Random.Range(0, DaftarNPC.Count);

            GameObject SpawnNpc = Instantiate(DaftarNPC[RandomAngka], this.gameObject.transform.position, this.gameObject.transform.rotation);

            SpawnNpc.GetComponent<NPCScript>().Player = Player;

            SpawnNpc.GetComponent<NPCScript>().spawnNPC = this;

            SpawnNpc.GetComponent<NPCScript>().waypoint = this.GetComponent<WaypointAja>();

            Already_Spawn = true;

            
        }   
    }
}
