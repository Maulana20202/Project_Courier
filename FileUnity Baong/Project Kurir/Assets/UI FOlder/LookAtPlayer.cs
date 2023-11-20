using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public GameObject CameraUtama;
    // Start is called before the first frame update
    void Start()
    {
        CameraUtama = GameObject.FindWithTag("MainCamera").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CameraUtama.transform);
    }
}
