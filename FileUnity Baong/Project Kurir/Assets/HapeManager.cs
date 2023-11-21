using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HapeManager : MonoBehaviour
{

    public GameObject Minimap;

    public GameObject Keluar;

    public GameObject HP;

    public GameObject MainMenu;
    public GameObject LoadingScreen;


    PlayerCameraRotation playerCameraRotation;

    public Slider SliderProgressValue;
    // Start is called before the first frame update
    void Start()
    {
        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("h")){
            HP.SetActive(true);
            Minimap.SetActive(false);
            Keluar.SetActive(false);
            playerCameraRotation.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void MinimapKeluar(){
        Minimap.SetActive(true);
        Keluar.SetActive(false);
    }

    public void KeluarHape(){
        Minimap.SetActive(false);
        Keluar.SetActive(true);
    }

    public void KeluarGame(){
       StartCoroutine(LoadingScreenWait(0));
       Destroy(AudioManager.instance.gameObject);
    }

    public void GajadiKeluar(){
        Minimap.SetActive(false);
        Keluar.SetActive(false);
    }

    public void SimpanHape(){
        
            HP.SetActive(false);
            Minimap.SetActive(false);
            Keluar.SetActive(false);
            playerCameraRotation.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
    }


    IEnumerator LoadingScreenWait(int LevelToLoad){

         AsyncOperation loadOperation = SceneManager.LoadSceneAsync(LevelToLoad);

        while (!loadOperation.isDone){
            
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            SliderProgressValue.value = progressValue;

            yield return null;
        }
    }


}
