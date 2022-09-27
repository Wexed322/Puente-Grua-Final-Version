using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBobinas : MonoBehaviour
{
    //ANGULO
    public Transform pivote;
    public GameObject currentBobina;
    public float angulo;

    //PENDULOS
    public int cantidadDePendulos;

    //EMPEZO PROCESOS
    public PuertaEscenaIzaje1 puertaIzaje;
    public int identificador;



    public bool soloUnaVez;


    void Start()
    {
        identificador = 0;
        cantidadDePendulos = 0;
        soloUnaVez = true;
    }

    void Update()
    {
        if (currentBobina != null) 
        {
            angulo =  Vector3.Angle((pivote.position - currentBobina.transform.position).normalized, this.transform.up);
            if (angulo > 4) 
            {
                StartCoroutine(cantidadPendulosFunction());
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bobina"))
        {
            currentBobina = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bobina"))
        {
            if (identificador < 2) 
            {
                if (puertaIzaje.ProcesobobinasDeAcero == false && other.gameObject.GetComponent<Content>().tagContainer == "ContenedorBuggy")
                {
                    puertaIzaje.ProcesobobinasDeAcero = true;
                    identificador++;

                }
                else if (puertaIzaje.ProcesobobinasMarrones == false && other.gameObject.GetComponent<Content>().tagContainer == "ContenedorBobinaMarron")
                {
                    puertaIzaje.ProcesobobinasMarrones = true;
                    identificador++;
                }
                else
                {

                }
            }
           
            currentBobina = other.gameObject;
        }
    }
    

    IEnumerator cantidadPendulosFunction() 
    {
        if (soloUnaVez) 
        {
            soloUnaVez = false;
            cantidadDePendulos++;
            yield return new WaitForSeconds(20);
            soloUnaVez = true;
        }

    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(pivote.position, currentBobina.transform.position);
    }
}
