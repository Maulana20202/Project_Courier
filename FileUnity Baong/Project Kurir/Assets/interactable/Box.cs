using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    public bool IsMengambil;

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
        
            if ( Diambil){
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Diambil = false;
                    rb.AddForce(transform.right * -5f, ForceMode.Impulse);
                    this.transform.SetParent(null);
                    rb.useGravity = true;
                    rb.constraints = RigidbodyConstraints.None;
                    BC.enabled = true;
                    

                    BoxStatsContainer.Instance.RemoveBoxStats();
                }
            }
            

        nyawaBarang = boxStats.nyawaBarang;

        if(IsMengambil){
            StartCoroutine(DelayDiambil());
        }
        

    }

    protected override void Interact()
    {
        if (Diambil == false)
        {
            IsMengambil = true;
            BoxStatsContainer.Instance.AddBoxStats(boxStats, thisBox, nyawaBarang);
        }
        
        
    }


    private IEnumerator DelayDiambil()
    {
        transform.rotation = titikAmbilBarang.rotation;
        transform.position = Vector3.Lerp(transform.position,titikAmbilBarang.position,10f * Time.deltaTime);
        
        
        this.transform.SetParent(playerUtama.transform.GetChild(1));
        rb.useGravity = false;
        BC.enabled = false;
        BoxStatsContainer.Instance.boxStatsObject = this.gameObject;
        
       
            
        yield return new WaitForSeconds(0.4f);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        Diambil = true;
        IsMengambil = false;
        

    }
}
