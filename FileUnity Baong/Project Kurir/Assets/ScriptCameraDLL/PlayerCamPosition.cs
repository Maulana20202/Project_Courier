using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamPosition : MonoBehaviour
{
    //untuk nyimpen titik posisi kamera

    public Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //untuk ngarahin kamera ke player

        transform.position = cameraPosition.position;
    }
}
