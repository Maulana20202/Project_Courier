using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Misi_0_LuarCne : MonoBehaviour
{
    public BoxStats Box_1;
    public BoxStats Box_2;
    public BoxStats Box_3;
    public BoxStats Box_4;
    public BoxStats Box_5;
    
    //Prefabs Penerima

    public GameObject Penerima_1;
    public GameObject Penerima_2;
    public GameObject Penerima_3;
    public GameObject Penerima_4;
    public GameObject Penerima_5;


    GameObject _Penerima_1;
    GameObject _Penerima_2;
    GameObject _Penerima_3;
    GameObject _Penerima_4;
    GameObject _Penerima_5;


    //Transform Lokasi

    public Transform LokasiPenerima1;
    public Transform LokasiPenerima2;
    public Transform LokasiPenerima3;
    public Transform LokasiPenerima4;
    public Transform LokasiPenerima5;

    //Jumlah Misi Yang Ada dan yang tersisa

    public int JumlahMison;

    public int JumlahMisiCurrent;
    
    public void Start(){

    }


    public void OnEnable(){
        
        _Penerima_1 = Instantiate(Penerima_1, LokasiPenerima1.position, Quaternion.identity,  LokasiPenerima1);

        _Penerima_1.GetComponent<PenerimaBox>().box = Box_1;

        _Penerima_1.GetComponent<PenerimaBox>().promptMessage = Box_1.NamaBox;



        _Penerima_2 = Instantiate(Penerima_2, LokasiPenerima2.position, Quaternion.identity,  LokasiPenerima2);

        _Penerima_2.GetComponent<PenerimaBox>().box = Box_2;

        _Penerima_2.GetComponent<PenerimaBox>().promptMessage = Box_2.NamaBox;


        _Penerima_3 = Instantiate(Penerima_3, LokasiPenerima3.position, Quaternion.identity,  LokasiPenerima3);

        _Penerima_3.GetComponent<PenerimaBox>().box = Box_3;

        _Penerima_3.GetComponent<PenerimaBox>().promptMessage = Box_3.NamaBox;


        _Penerima_4 = Instantiate(Penerima_4, LokasiPenerima4.position, Quaternion.identity,  LokasiPenerima4);

        _Penerima_4.GetComponent<PenerimaBox>().box = Box_4;

        _Penerima_4.GetComponent<PenerimaBox>().promptMessage = Box_4.NamaBox;


        _Penerima_5 = Instantiate(Penerima_5, LokasiPenerima5.position, Quaternion.identity,  LokasiPenerima5);

        _Penerima_5.GetComponent<PenerimaBox>().box = Box_5;

        _Penerima_5.GetComponent<PenerimaBox>().promptMessage = Box_5.NamaBox;


        JumlahMisi.instance.jumlahMission = JumlahMison;

        JumlahMisi.instance.JumlahMisiCurrent = JumlahMison;

    }


    void OnDisable (){
        
        Destroy(_Penerima_1);
        Destroy(_Penerima_2);
        Destroy(_Penerima_3);
        Destroy(_Penerima_4);
        Destroy(_Penerima_5);

    }

}
