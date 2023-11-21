using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusikGanti : MonoBehaviour
{

    public GameObject BGMSiang;

    public GameObject BGMMalam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UIWaktuScript.Instance.hour >= 18 && UIWaktuScript.Instance.hour >= 24 || UIWaktuScript.Instance.hour >= 0 && UIWaktuScript.Instance.hour >= 4 ){
            
            StartCoroutine(DelayGanti());
        } else {
            StartCoroutine(DelayGantiAlter());
        }
        
    }

    IEnumerator DelayGanti(){
       BGMSiang.GetComponent<Animator>().SetBool("FadeIn", false);
            BGMSiang.GetComponent<Animator>().SetBool("FadeOut", true);
;            this.gameObject.GetComponent<AudioManager>().Audio = BGMMalam.GetComponent<AudioSource>();
        yield return new WaitForSeconds(2);
         BGMMalam.GetComponent<Animator>().SetBool("FadeIn", true);
            BGMMalam.GetComponent<Animator>().SetBool("FadeOut", false);
    }

    IEnumerator DelayGantiAlter(){
        BGMMalam.gameObject.GetComponent<Animator>().SetBool("FadeIn", false);
            BGMMalam.gameObject.GetComponent<Animator>().SetBool("FadeOut", true);
;            this.gameObject.GetComponent<AudioManager>().Audio = BGMSiang.GetComponent<AudioSource>();
        yield return new WaitForSeconds(2);
        BGMSiang.gameObject.GetComponent<Animator>().SetBool("FadeIn", true);
            BGMSiang.gameObject.GetComponent<Animator>().SetBool("FadeOut", false);
    }
}

