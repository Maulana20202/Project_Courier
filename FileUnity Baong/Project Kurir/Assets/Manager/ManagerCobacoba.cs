using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCobacoba : MonoBehaviour
{

    public GameManager gameManager;

    public List<bool> yaya = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaya = gameManager.UnlockKendaraan;
    }
}
