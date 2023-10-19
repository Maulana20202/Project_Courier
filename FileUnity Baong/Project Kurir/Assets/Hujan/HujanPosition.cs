using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HujanPosition : MonoBehaviour
{


    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        /*playerPos = GameObject.FindWithTag("PlayerUtama").transform;*/
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerPos.position.x, this.transform.position.y, playerPos.position.z);
    }
}
