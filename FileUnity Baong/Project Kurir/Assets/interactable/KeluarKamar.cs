using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeluarKamar : interactable
{
    public GameObject MainMenu;
    public GameObject LoadingScreen;

    public Slider SliderProgressValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact(){

        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadingScreenWait(1));
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
