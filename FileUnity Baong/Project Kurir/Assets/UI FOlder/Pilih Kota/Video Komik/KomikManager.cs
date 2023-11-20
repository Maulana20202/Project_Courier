using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomikManager : MonoBehaviour
{
    public bool playCountDown;

    public GameObject Video1;
    public GameObject Video2;
    public GameObject Video3;

    public GameObject GameUI;

    public PlayerMovement playerMovement;
    public PlayerCameraRotation playerCameraRotation;

    public float HitungMundurCurrent;
    void Start()
    {
        
        playerMovement = FindAnyObjectByType<PlayerMovement>();

        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();

        if(GameManager.Instance.KotaTerpilih[2] == true && GameManager.Instance.KotaKomik[2] == false){
            Video2.SetActive(true);
            GameUI.SetActive(false);
            playCountDown = true;
            GameManager.Instance.KotaKomik[2] = true;
            HitungMundurCurrent = 248f;
            UIWaktuScript.Instance.TIMESCALE = 0;
            UIWaktuScript.Instance.gameObject.GetComponent<LightingManager>().MatahariStop = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.enabled = false;
            playerCameraRotation.enabled = false;

        } else if(GameManager.Instance.KotaTerpilih[3] == true && GameManager.Instance.KotaKomik[3] == false){
            Video3.SetActive(true);
            GameUI.SetActive(false);
            playCountDown = true;
            GameManager.Instance.KotaKomik[3] = true;
            UIWaktuScript.Instance.TIMESCALE = 0;
            UIWaktuScript.Instance.gameObject.GetComponent<LightingManager>().MatahariStop = true;
            HitungMundurCurrent = 248f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.enabled = false;
            playerCameraRotation.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playCountDown == true){
            if(HitungMundurCurrent <= 0){
                Video1.SetActive(false);
                Video2.SetActive(false);
                Video3.SetActive(false);
                GameUI.SetActive(true);
                playCountDown = false;
                UIWaktuScript.Instance.TIMESCALE = 100;
                UIWaktuScript.Instance.gameObject.GetComponent<LightingManager>().MatahariStop = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerMovement.enabled = true;
                playerCameraRotation.enabled = true;
                AudioManager.instance.Audio.gameObject.GetComponent<Animator>().SetBool("FadeIn", true);
                AudioManager.instance.Audio.gameObject.GetComponent<Animator>().SetBool("FadeOut", false);
            } else {
                HitungMundurCurrent -= Time.deltaTime;
            }
        }
    }
    
}
