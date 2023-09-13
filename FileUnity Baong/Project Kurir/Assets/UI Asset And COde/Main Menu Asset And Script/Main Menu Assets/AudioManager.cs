using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource Audio;
    // Start is called before the first frame update

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
        Audio = GameObject.FindWithTag("Bgm").GetComponent<AudioSource>();
    }
    void Start()
    {
        
        Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
