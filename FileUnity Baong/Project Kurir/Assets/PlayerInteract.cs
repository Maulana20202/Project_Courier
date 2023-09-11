using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract instance; 

    public Camera cam;
    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;
    public PlayerUI playerUI;

    public GameObject player;

    public bool RayCastCheck;
    // Start is called before the first frame update
    void Start()
    {
       playerUI = GetComponent<PlayerUI>();
       instance = this;
       player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray r = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(r.origin, r.direction * distance);
        RaycastHit hitInfo;
       if( Physics.Raycast(r, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<interactable>() != null)
            {
                RayCastCheck = true;
                interactable interactable = hitInfo.collider.GetComponent<interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }

                if (Input.GetKeyDown(KeyCode.G))
                {
                    interactable.BaseInteractAlter();
                }
            } 
            else
            {
                RayCastCheck = false;
            }
        }

    }
}
