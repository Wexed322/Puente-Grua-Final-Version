using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public List<MonoBehaviour> objetosContenidos;
    public int cantidadMaximaParaAccion;

    public bool llamarSoloUnaVez;

    public virtual void reactionAfterBeingFull() 
    {
        Debug.Log("haciendo accion");
    }
}
