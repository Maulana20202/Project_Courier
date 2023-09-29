using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectorBox : MonoBehaviour
{

    public Box Box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    void OnTriggerEnter(Collider col){

        if(col.gameObject.GetComponent<Box>() != null){
            Box = col.gameObject.GetComponent<Box>();
        }
    }
}
