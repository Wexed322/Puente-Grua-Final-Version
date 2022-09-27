using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeCargas : MonoBehaviour
{
    [SerializeField] int contadorMalAngulo;
    [SerializeField] bool empezoProceso;

    public float tiempoEnElProceso;

    public bool EmpezoProceso { get => empezoProceso; }
    public int ContadorMalAngulo { get => contadorMalAngulo;}

    private void Start()
    {
        contadorMalAngulo = 0;
    }
    private void Update()
    {
        if (empezoProceso) 
        {
            tiempoEnElProceso += Time.deltaTime;
        }
    }
    public void add1Contador() 
    {
        contadorMalAngulo++;
    }

    public void procesoIniciado() 
    {
        empezoProceso = true;
    }

    public void deterContador()
    {
        empezoProceso = false;
    }

}
