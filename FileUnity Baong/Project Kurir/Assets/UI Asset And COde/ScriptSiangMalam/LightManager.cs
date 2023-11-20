using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private Light DirectionalLight2;
    [SerializeField] private DirectionalColorPreset Preset;

    [SerializeField] private DirectionalColorPreset PresetHujan;
    //Variables
    [SerializeField, Range(0,86400)] public float TimeOfDay;
    public bool MatahariStop;


    void Awake(){
        TimeOfDay = 18000;
    }

    private void Update()
    {

        if(GameObject.FindWithTag("Matahari") != null){
            DirectionalLight = GameObject.FindWithTag("Matahari").GetComponent<Light>();
        }
       

        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            if(DirectionalLight != null){
                //(Replace with a reference to the game time)
                if(!MatahariStop){
                    TimeOfDay += Time.deltaTime * 100;
                }  
                TimeOfDay %= 86400; //Modulus to ensure always between 0-24
                UpdateLighting(TimeOfDay / 86400f);
            }
            
        }
        else
        {
            if(DirectionalLight != null){
                UpdateLighting(TimeOfDay / 86400f);
            }
        }
    }


    private void UpdateLighting(float timePercent)
    {
        if (DirectionalLight != null)
        {
            if(HujanTrigger.Instance != null && HujanTrigger.Instance.HujanMulai != true){
                RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
                RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
            } else {
                RenderSettings.ambientLight = PresetHujan.AmbientColor.Evaluate(timePercent);
                RenderSettings.fogColor = PresetHujan.FogColor.Evaluate(timePercent);
            }
        }
        //Set ambient and fog
       

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            if(HujanTrigger.Instance != null && HujanTrigger.Instance.HujanMulai != true){
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            } else {
                DirectionalLight.color = PresetHujan.DirectionalColor.Evaluate(timePercent);
            }
            

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
            
             DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    
    
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
    
}
