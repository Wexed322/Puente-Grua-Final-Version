using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    [SerializeField]
    InteractuableObject interactuableObject;

    void Update()
    {
        if (interactuableObject != null) 
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                interactuableObject.drop();
                interactuableObject = null;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                interactuableObject.UsarObject();
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
                interactuableObject = other.gameObject.GetComponent<InteractuableObject>();
                firstActionofObjects(interactuableObject);

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

    public void firstActionofObjects(InteractuableObject a) 
    {
        if (a.myType == TypeInteractionObject.interactuable)
        {
            a.FirstActionWith(this.transform);//se va a la mano
        }
        else if (a.myType == TypeInteractionObject.observable) 
        {
            a.FirstActionWith();
        }
    }
}
