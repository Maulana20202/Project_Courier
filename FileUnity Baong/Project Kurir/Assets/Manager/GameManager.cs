using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public List<bool> UnlockKendaraan = new List<bool>();

    public List<bool> KotaTerpilih = new List<bool>();

    public List<bool> KotaKomik = new List<bool>();

    public List<bool> KotaUnlock = new List<bool>();

    public List<int> KotaUnlockHarga = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
