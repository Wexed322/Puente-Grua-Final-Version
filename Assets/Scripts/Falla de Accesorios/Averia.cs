using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Averia : MonoBehaviour
{
    public AccesoriosData myData;
    public bool fallar;
    public void Start()
    {
        fallar = myData.examinado ? false : true;
    }

    public virtual void restauracionFunction() 
    {

    }
    public virtual void fallarFunction() 
    {

    }
}
