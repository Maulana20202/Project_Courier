using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public Animator AnimasiPressStart;

    public GameObject Kardus;
    public GameObject Judul;
    public GameObject Blur;
    public GameObject PressSpace;

    public GameObject AudioMusic;

    public GameObject Video1;

    public GameObject Video2;

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
            Kardus.GetComponent<Animator>().SetBool("Kardus Keluar", true);
            Judul.GetComponent<Animator>().SetBool("Judul Keluar", true);
            StartCoroutine("DelayAnimasiKardusKeluar");
            PressSpace.SetActive(true);
        }
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
