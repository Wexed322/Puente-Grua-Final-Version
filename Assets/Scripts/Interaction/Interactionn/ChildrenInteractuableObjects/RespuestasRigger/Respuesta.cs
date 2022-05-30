using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{
    public InteractuableRigger rigger;
    public bool respuestaCorrecta;
    public static bool primeraRespuesta;
    void Start()
    {
        primeraRespuesta = false;
    }
    public void presionLaCorrecta() 
    {
        if (!primeraRespuesta)
        {
            Debug.Log(respuestaCorrecta);
            if (respuestaCorrecta)
            {
                rigger.empezarCaminarFunction();
            }
            else 
            {

            }
            primeraRespuesta = true;
            //logica de enviar los datos al excel supongo
        }
        else 
        {

        }
    }
}
