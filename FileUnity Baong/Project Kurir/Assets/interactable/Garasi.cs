using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Garasi : interactable
{

    public GameObject camBagasi;

    public GameObject camPlayer;

    public GameObject UIGameplay;

    public GameObject UIGarasi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Interact(){

        camBagasi.SetActive(true);
        camPlayer.SetActive(false);

        UIGameplay.SetActive(false);
        UIGarasi.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
