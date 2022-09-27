using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDescarga : Container
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void reactionAfterBeingFull()
    {
        if (this.llamarSoloUnaVez == false) 
        {
            Debug.Log("asdsadasdsad");
            this.llamarSoloUnaVez = true;
        }
    }
}
