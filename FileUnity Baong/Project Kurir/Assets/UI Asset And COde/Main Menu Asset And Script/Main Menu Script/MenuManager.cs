using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public Animator AnimasiPressStart;

    public GameObject Kardus;
    public GameObject Judul;
    public GameObject Blur;
    public GameObject PressSpace;

    public GameObject AudioMusic;

    public GameObject Audio;

    public GameObject BonusContent;

    public GameObject Credit;

    public GameObject Video1;

    public GameObject Video2;

    public GameObject VideoPrologue;

    public GameObject VideoEpilogue;

    public bool AudioBuka;

    public bool BonusContentBuka;

    public bool CreditBuka;

    public bool ProloguePlay;

    public bool EpiloguePlay;

    public AudioSource Sound;

    // Start is called before the first frame update
    void Start()
    {
        AnimasiPressStart.SetBool("Kelar Masuk", false);
        AnimasiPressStart.SetBool("Baru Masuk", true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DelayAnimasiPressStart());
        StartCoroutine(DelayVideo());


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kardus.GetComponent<Animator>().SetBool("Kardus Keluar", false);
            Judul.GetComponent<Animator>().SetBool("Judul Keluar", false);
            Kardus.SetActive(true);
            Judul.SetActive(true);
            Blur.SetActive(true);
            PressSpace.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(AudioBuka == true){
                Audio.SetActive(false);
                AudioBuka = false;
            } else if (BonusContentBuka == true){
                BonusContent.SetActive(false);
                BonusContentBuka = false;
            } else if(CreditBuka == true){
                Credit.SetActive(false);
                BonusContent.SetActive(true);
                Kardus.SetActive(true);
                CreditBuka = false;
                BonusContentBuka = true;
            } else if(ProloguePlay == true){
                Sound.enabled = true;
                VideoPrologue.SetActive(false);
                ProloguePlay = false;
            } else if (EpiloguePlay == true){
                Sound.enabled = true;
                VideoEpilogue.SetActive(false);
                EpiloguePlay = false;
            }
             else {
                 Kardus.GetComponent<Animator>().SetBool("Kardus Keluar", true);
                Judul.GetComponent<Animator>().SetBool("Judul Keluar", true);
                StartCoroutine("DelayAnimasiKardusKeluar");
                PressSpace.SetActive(true);
            }
           
        }
    }

    public void BukaAudio(){
        Audio.SetActive(true);
        AudioBuka = true;
    }

    public void BukaBonusContent(){
        BonusContent.SetActive(true);
        BonusContentBuka = true;
    }

    public void BukaCredit(){
        BonusContent.SetActive(false);
        Credit.SetActive(true);
        Kardus.SetActive(false);
        CreditBuka = true;
        BonusContentBuka = false;
    }

    public void BukaPrologue(){
        Sound.enabled = false;
        VideoPrologue.SetActive(true);
        ProloguePlay = true;
    }

    public void BukaEpilogue(){
        Sound.enabled = false;
        VideoEpilogue.SetActive(true);
        EpiloguePlay = true;
    }

    public void quit(){
        Application.Quit();
    }



    IEnumerator DelayAnimasiPressStart()
    {
        yield return new WaitForSeconds(3f);

        AnimasiPressStart.SetBool("Kelar Masuk", true);
        AnimasiPressStart.SetBool("Baru Masuk", false);

        yield return new WaitForSeconds(1f);
   
        AudioMusic.SetActive(true);

       yield return null;
    }

    IEnumerator DelayAnimasiKardusKeluar()
    {
        yield return new WaitForSeconds(0.5f);
        Kardus.SetActive(false);
        Judul.SetActive(false);
        Blur.SetActive(false);
    }


    IEnumerator DelayVideo(){
        yield return new WaitForSeconds(4f);

            Video1.SetActive(false);
            Video2.SetActive(true);

        
    }
}
