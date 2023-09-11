using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] public GameObject LoadingScreen;
    [SerializeField] public Slider SliderLoadingScreen;

    [SerializeField] public GameObject MainMenu;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void LoadSceneBTN (int LevelToLoad){

        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadScene(LevelToLoad));

    }

    IEnumerator LoadScene (int LevelToLoad){

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(LevelToLoad);

        while (!loadOperation.isDone){
            
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            SliderLoadingScreen.value = progressValue;

            yield return null;
        }


    }
}
