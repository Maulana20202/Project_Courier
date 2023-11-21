using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public Animator animBlackScreen;

    public MasukKamar masukKamar;

    public GameObject MainMenu;

    public GameObject LoadingScreen;

    public SaveUntukJamPulang SaveTelat;

    public Slider SliderProgressValue;

    public PlayerMovement playerMovement;

    public PlayerCameraRotation playerCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerCameraRotation = FindAnyObjectByType<PlayerCameraRotation>();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Event Terlambat Pulang

        if(UIWaktuScript.Instance.hour == 20){
            
            SaveTelat.Telat = true;
            StartCoroutine(LoadingScreenWait(1));
        }

        if(playerMovement.StatsPerut <= 0){
            StartCoroutine(perutAbis());
        }
    }


    public IEnumerator LoadingScreenWait(int LevelToLoad){ // IEnumerator untuk event terlambat pulang

        animBlackScreen.SetBool("FadeIn", true);
        yield return new WaitForSeconds (2f);

        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);
        
         AsyncOperation loadOperation = SceneManager.LoadSceneAsync(LevelToLoad);

        while (!loadOperation.isDone){
            
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            SliderProgressValue.value = progressValue;

            yield return null;
        }
    }

    

    IEnumerator perutAbis(){
        animBlackScreen.SetBool("FadeOut", false);
        animBlackScreen.SetBool("FadeIn", true);

        playerCameraRotation.enabled = false;
        playerMovement.enabled = false;

        yield return new WaitForSeconds(6);
        if( UIDuitScript.instance.JumlahUang >= 40000){
            UIDuitScript.instance.JumlahUang -= 40000;
        } else {
            UIDuitScript.instance.JumlahUang = 0;
        }
        
        playerMovement.StatsPerut = 100;

        animBlackScreen.SetBool("FadeOut", true);
        animBlackScreen.SetBool("FadeIn", false);
        

        yield return new WaitForSeconds(2);

        playerCameraRotation.enabled = true;
        playerMovement.enabled = true;

    }

    
}
