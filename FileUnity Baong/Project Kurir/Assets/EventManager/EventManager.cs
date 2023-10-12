using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

    public Animator animBlackScreen;

    public MasukKamar masukKamar;

    public GameObject MainMenu;

    public GameObject LoadingScreen;

    public SaveUntukJamPulang SaveTelat;

    public Slider SliderProgressValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Event Terlambat Pulang

        if(UIWaktuScript.Instance.hour == 20){
            
            SaveTelat.Telat = true;
            StartCoroutine(LoadingScreenWait(1));
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
}
