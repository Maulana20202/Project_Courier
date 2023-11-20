using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{

    public string promptMessage;

    public GameObject Atasan;


    public void BaseInteract()
    {
        Interact();
    }

    public void BaseInteractAlter()
    {
        InteractAlter();
    }

    protected virtual void Interact() { 
    
        
    
    }

    protected virtual void InteractAlter()
    {

    }
}
