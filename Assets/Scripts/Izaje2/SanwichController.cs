using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanwichController : MonoBehaviour
{
    //IZJAE
    public bool enContactoConCarga;
    public bool conCarga;
    public GameObject baseSandwich;

    public Tubo currentTubo;


    //CONTADOR
    public ControlDeCargas referenceControlDeCargas;
    void Start()
    {
        baseSandwich.gameObject.SetActive(false);
    }

    void Update()
    {
        if (enContactoConCarga && Input.GetKeyDown(KeyCode.I) && !conCarga)
        {
            if (withinAngle(currentTubo.transform, 3))
            {
                currentTubo.activeDesactiveBaseCollider(false);
                baseSandwich.gameObject.SetActive(true);
                conCarga = true;
            }
            else 
            {
                referenceControlDeCargas.add1Contador();
            }
        }

        else if (enContactoConCarga && Input.GetKeyDown(KeyCode.I) && conCarga) 
        {
            baseSandwich.gameObject.SetActive(false);
            conCarga = false;

            currentTubo.activeDesactiveBaseCollider(true);
            currentTubo = null;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tubo") && !conCarga) 
        {
            referenceControlDeCargas.procesoIniciado();
            currentTubo = collision.gameObject.GetComponent<Tubo>();
            enContactoConCarga = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tubo") && !conCarga)
        {
            enContactoConCarga = false;
        }
    }

    public bool withinAngle(Transform tubos, float ampplitud)
    {
        if (Vector3.Angle(this.transform.right, -tubos.transform.right) < ampplitud || Vector3.Angle(this.transform.right, tubos.transform.right) < ampplitud)
        {
            return true;
        }
        
        return false;
    }
}
