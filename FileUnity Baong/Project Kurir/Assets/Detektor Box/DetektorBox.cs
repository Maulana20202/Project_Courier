using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetektorBox : MonoBehaviour
{

    public Box box;
    
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
            box = col.gameObject.GetComponent<Box>();
        }
    }
}
