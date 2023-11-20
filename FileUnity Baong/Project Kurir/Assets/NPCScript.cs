using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{

    public NavMeshAgent Agent;
    [SerializeField] private Transform[] PathPoints;

     public WaypointAja waypoint;

     public SpawnNPC spawnNPC;

     public GameObject Player;

    public int Index;

    public float MinimumDistance = 2;

    public float MaximumDistance;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.SetDestination(waypoint.transform.position);

        MaximumDistance = 70f;
    }

    // Update is called once per frame
    void Update()
    {
        Roam();

        DeSpawn();
    }
    

    void Roam(){

       if(Vector3.Distance(transform.position, waypoint.transform.position) < MinimumDistance){


             waypoint = waypoint.nextWaypoint;

             Agent.SetDestination(waypoint.transform.position);
        
           
        }
        

    }

    void DeSpawn(){
        if(Vector3.Distance(transform.position, Player.transform.position) > MaximumDistance){
            spawnNPC.Already_Spawn = false;
            Destroy(this.gameObject);
        }
    }
}
