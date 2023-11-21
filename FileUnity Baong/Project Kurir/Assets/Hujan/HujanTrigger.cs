using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class HujanTrigger : MonoBehaviour
{

    public static HujanTrigger Instance;
    public Material cloud;

    public GameObject Hujan;

    public bool HujanMulai;

    public MeshCollider Lantai;

    public PhysicMaterial MaterialLicin;

    public GameObject DirectionalColor;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(HujanMulai == true){
            Hujan.SetActive(true);
            Lantai.material = MaterialLicin;
            DirectionalColor.SetActive(false);
        } else {
            Hujan.SetActive(false);
            Lantai.material = null;
            DirectionalColor.SetActive(true);
        }
    }

    public void PakaiJasHujan(){
        if(JasHujanTempat.instance.JasHujan >= 1){
            JasHujanTempat.instance.PakeJasHujan = true;
            JasHujanTempat.instance.JasHujan -= 1;
        }
        
    }
}
