using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "Box Stats", menuName = "box/Create New Box") ]
public class BoxStats : ScriptableObject
{
    public string NamaBox;
    public string Deskripsi;
    public int id;
    public float Berat;
    public Sprite GambarBarang;
    public int nyawaBarang;

    public JenisBarang jenis;

    public GameObject prefabsBox;

    public enum JenisBarang
    {
        Fragile,
        Non_Fragile
    }
}
