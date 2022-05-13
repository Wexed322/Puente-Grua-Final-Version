using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    [SerializeField]
    Interactuables interactuableObject;

    void Update()
    {
        if (interactuableObject != null) 
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                interactuableObject.Drop();
                interactuableObject = null;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //UI.instance.showMessage(other.gameObject.GetComponent<PickObject>().id);

            if (interactuableObject == null && Input.GetKeyDown(KeyCode.E))
            {
                interactuableObject = other.gameObject.GetComponent<Interactuables>();
                actionAfterContact(interactuableObject);

            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.layer == 8)
        {
            UI.instance.hideMessage();
        }*/

    }

    public void actionAfterContact(Interactuables objectInteract) 
    {
        //objectInteract.examinado();
        if (objectInteract.myType == TypeInteractionObject.observable)
        {
            objectInteract.FocusCamera();
        }
        else if (objectInteract.myType == TypeInteractionObject.interactuable)
        {

        }
        else 
        {
            objectInteract.putInHand(this.transform);
        }
    }
}
