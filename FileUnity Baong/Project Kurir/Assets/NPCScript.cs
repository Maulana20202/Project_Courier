using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{

    public NavMeshAgent Agent;
    [SerializeField] private Transform[] PathPoints;

    public int Index;

    public float MinimumDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Roam();
    }
    

    void Roam(){

     if(Vector3.Distance(transform.position, PathPoints[Index].position) < MinimumDistance){
            if(Index >= 0 && Index < PathPoints.Length - 1){         
                Index += 1;
            } else {
                Index = 0;
            }
        }

        Agent.SetDestination(PathPoints[Index].position);

    }
}
