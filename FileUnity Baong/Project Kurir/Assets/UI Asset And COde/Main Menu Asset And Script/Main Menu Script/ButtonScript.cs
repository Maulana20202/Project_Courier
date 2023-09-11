using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject[] Lakban;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pointer Event Trigger

        //Pointer Tombol Continue Hover
        public void PointerMasuk()
        {
            Lakban[0].GetComponent<Animator>().SetBool("Lakban Keluar", true);
            Lakban[0].GetComponent<Animator>().SetBool("Lakban Masuk", false);

        }

        public void PointerKeluar()
        {
            Lakban[0].GetComponent<Animator>().SetBool("Lakban Keluar", false);
            Lakban[0].GetComponent<Animator>().SetBool("Lakban Masuk", true);
        }


        //Pointer Tombol New Game Hover
        public void PointerMasukNewGame()
        {
            Lakban[1].GetComponent<Animator>().SetBool("Lakban Keluar", true);
            Lakban[1].GetComponent<Animator>().SetBool("Lakban Masuk", false);

        }

        public void PointerKeluarNewGame()
        {
            Lakban[1].GetComponent<Animator>().SetBool("Lakban Keluar", false);
            Lakban[1].GetComponent<Animator>().SetBool("Lakban Masuk", true);
        }


        //Pointer Tombol Settings Hover

        public void PointerMasukSettings()
        {
            Lakban[2].GetComponent<Animator>().SetBool("Lakban Keluar", true);
            Lakban[2].GetComponent<Animator>().SetBool("Lakban Masuk", false);

        }

        public void PointerKeluarSettings()
        {
            Lakban[2].GetComponent<Animator>().SetBool("Lakban Keluar", false);
            Lakban[2].GetComponent<Animator>().SetBool("Lakban Masuk", true);
        }

        //Pointer Tombol Quit Hover

        public void PointerMasukQuit()
        {
            Lakban[3].GetComponent<Animator>().SetBool("Lakban Keluar", true);
            Lakban[3].GetComponent<Animator>().SetBool("Lakban Masuk", false);

        }

        public void PointerKeluarQuit()
        {
            Lakban[3].GetComponent<Animator>().SetBool("Lakban Keluar", false);
            Lakban[3].GetComponent<Animator>().SetBool("Lakban Masuk", true);
        }


    // Event Trigger Button

    public void PencetContinue()
    {
        Debug.Log("kepencet");
    }
}
