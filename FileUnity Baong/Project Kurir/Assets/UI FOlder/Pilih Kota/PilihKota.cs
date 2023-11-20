using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class PilihKota : MonoBehaviour
{

    public int Index;

    public GameObject GambarKota;

    public GameObject TitleKota;

    public TextMeshProUGUI HargaKota;

    public PlayerMovement playerMovement;

    public PlayerCameraRotation playerCameraRotation;
    public GameObject UIPilihKota;

    public GameObject BlackScreen;

    public MasukKamar masukKamar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanjutIndex(){
        if(Index > 0){
            Index++;

            if(Index == 1){
                GambarKota.transform.GetChild(0).gameObject.SetActive(true);
                GambarKota.transform.GetChild(1).gameObject.SetActive(false);
                GambarKota.transform.GetChild(2).gameObject.SetActive(false);

                TitleKota.transform.GetChild(0).gameObject.SetActive(true);
                TitleKota.transform.GetChild(1).gameObject.SetActive(false);
                TitleKota.transform.GetChild(2).gameObject.SetActive(false);

                
            }

            if(Index == 2){
                GambarKota.transform.GetChild(0).gameObject.SetActive(false);
                GambarKota.transform.GetChild(1).gameObject.SetActive(true);
                GambarKota.transform.GetChild(2).gameObject.SetActive(false);

                TitleKota.transform.GetChild(0).gameObject.SetActive(false);
                TitleKota.transform.GetChild(1).gameObject.SetActive(true);
                TitleKota.transform.GetChild(2).gameObject.SetActive(false);
            }

            if(Index == 3){
                GambarKota.transform.GetChild(0).gameObject.SetActive(false);
                GambarKota.transform.GetChild(1).gameObject.SetActive(false);
                GambarKota.transform.GetChild(2).gameObject.SetActive(true);

                TitleKota.transform.GetChild(0).gameObject.SetActive(false);
                TitleKota.transform.GetChild(1).gameObject.SetActive(false);
                TitleKota.transform.GetChild(2).gameObject.SetActive(true);
            }

            if(GameManager.Instance.KotaUnlock[Index] != true){
                    HargaKota.text = string.Format(CultureInfo.CreateSpecificCulture ("id-id"), "Rp {0:N0}", GameManager.Instance.KotaUnlockHarga[Index]);
                    GambarKota.transform.GetChild(3).gameObject.SetActive(true);
            } else {
                    HargaKota.text = null;
                    GambarKota.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }

    public void MundurIndex(){
        if(Index <= 3 && Index > 1){
            Index--;

            if(Index == 1){
                GambarKota.transform.GetChild(0).gameObject.SetActive(true);
                GambarKota.transform.GetChild(1).gameObject.SetActive(false);
                GambarKota.transform.GetChild(2).gameObject.SetActive(false);

                TitleKota.transform.GetChild(0).gameObject.SetActive(true);
                TitleKota.transform.GetChild(1).gameObject.SetActive(false);
                TitleKota.transform.GetChild(2).gameObject.SetActive(false);
            }

            if(Index == 2){
                GambarKota.transform.GetChild(0).gameObject.SetActive(false);
                GambarKota.transform.GetChild(1).gameObject.SetActive(true);
                GambarKota.transform.GetChild(2).gameObject.SetActive(false);

                TitleKota.transform.GetChild(0).gameObject.SetActive(false);
                TitleKota.transform.GetChild(1).gameObject.SetActive(true);
                TitleKota.transform.GetChild(2).gameObject.SetActive(false);
            }

            if(Index == 3){
                GambarKota.transform.GetChild(0).gameObject.SetActive(false);
                GambarKota.transform.GetChild(1).gameObject.SetActive(false);
                GambarKota.transform.GetChild(2).gameObject.SetActive(true);

                TitleKota.transform.GetChild(0).gameObject.SetActive(false);
                TitleKota.transform.GetChild(1).gameObject.SetActive(false);
                TitleKota.transform.GetChild(2).gameObject.SetActive(true);
            }

            if(GameManager.Instance.KotaUnlock[Index] != true){
                    HargaKota.text = string.Format(CultureInfo.CreateSpecificCulture ("id-id"), "Rp {0:N0}", GameManager.Instance.KotaUnlockHarga[Index]);
                    GambarKota.transform.GetChild(3).gameObject.SetActive(true);
            } else {
                    HargaKota.text = null;
                    GambarKota.transform.GetChild(3).gameObject.SetActive(false);
            }
        }
    }

    public void PilihinKota(){
        if(Index == 1){
            GameManager.Instance.KotaTerpilih[1] = true;
            GameManager.Instance.KotaTerpilih[2] = false;
            GameManager.Instance.KotaTerpilih[3] = false;
        } else if(Index == 2){
            GameManager.Instance.KotaTerpilih[1] = false;
            GameManager.Instance.KotaTerpilih[2] = true;
            GameManager.Instance.KotaTerpilih[3] = false;
        } else if(Index == 3){
            GameManager.Instance.KotaTerpilih[1] = false;
            GameManager.Instance.KotaTerpilih[2] = false;
            GameManager.Instance.KotaTerpilih[3] = true;
        }

        playerMovement = FindObjectOfType<PlayerMovement>();
        playerCameraRotation = FindObjectOfType<PlayerCameraRotation>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
        playerCameraRotation.enabled = true;

        UIPilihKota.SetActive(false);
    }

    public void BeliKota(){
        if(UIDuitScript.instance.JumlahUang >= GameManager.Instance.KotaUnlockHarga[Index]){
            GameManager.Instance.KotaUnlock[Index] = true;
            UIDuitScript.instance.JumlahUang -= GameManager.Instance.KotaUnlockHarga[Index];

            if(Index == 2){
                GameManager.Instance.KotaTerpilih[1] = false;
                GameManager.Instance.KotaTerpilih[2] = true;
                GameManager.Instance.KotaTerpilih[3] = false;
            } else if(Index == 3){
                GameManager.Instance.KotaTerpilih[1] = false;
                GameManager.Instance.KotaTerpilih[2] = false;
                GameManager.Instance.KotaTerpilih[3] = true;
            }

            UIPilihKota.SetActive(false);
            AudioManager.instance.Audio.gameObject.GetComponent<Animator>().SetBool("FadeOut", true);
            AudioManager.instance.Audio.gameObject.GetComponent<Animator>().SetBool("FadeIn", false);
            StartCoroutine(BlackScreenWait());
        }
    }

    IEnumerator BlackScreenWait(){
        BlackScreen.GetComponent<Animator>().SetBool("FadeIn", true);
        yield return new WaitForSeconds(4f);
        masukKamar.MasukKeKamar();
    }

   }
