using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : interactable
{
    public Transform titikAmbilBarang;
    public GameObject playerUtama;
    public Rigidbody rb;
    public BoxCollider BC;

    public BoxStats boxStats;
    public float nyawaBarang;
    public GameObject thisBox;

    public bool Diambil;

    private float Waktu = 1f;
    private float currentWaktu;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        playerUtama = GameObject.FindWithTag("PlayerUtama");
        titikAmbilBarang = playerUtama.transform.GetChild(1).transform.GetChild(0);
        rb = GetComponent<Rigidbody>();
        BC = GetComponent<BoxCollider>();
        thisBox = this.gameObject;

        currentWaktu = Waktu;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Diambil)
        {
            rb.velocity = playerUtama.GetComponent<Rigidbody>().velocity;
            rb.AddForce(transform.right * -5f, ForceMode.Impulse);
            this.transform.SetParent(null);
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            BC.enabled = true;
            Diambil = false;

            BoxStatsContainer.Instance.RemoveBoxStats();
        }

        nyawaBarang = boxStats.nyawaBarang;


    }

    protected override void Interact()
    {
        if (Diambil == false)
        {
            StartCoroutine(DelayDiambil());
        }
        BoxStatsContainer.Instance.AddBoxStats(boxStats, thisBox, nyawaBarang);
        
    }


    private IEnumerator DelayDiambil()
    {
       
        transform.position = titikAmbilBarang.position;
        transform.rotation = titikAmbilBarang.rotation;
        
        this.transform.SetParent(playerUtama.transform.GetChild(1));
        rb.useGravity = false;
        BC.enabled = false;
        BoxStatsContainer.Instance.boxStatsObject = this.gameObject;
            
        rb.constraints = RigidbodyConstraints.FreezePosition;
            
        yield return new WaitForSeconds(0.5f);
        Diambil = true;

    }
}
