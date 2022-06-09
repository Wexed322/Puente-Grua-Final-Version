using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveriaBotonera : Averia
{
    public HideButton referenceHideButton;
    new void Start()
    {
        base.Start();

        if (fallar && GameManager.GameManagerInstance.secuencia!=0)//ESTO DEL GAMEMANAGER PARA PODAMOS TESTEAR CON TRANQUILIDAD ANAHSIE
        {
            fallarFunction();
        }
        else 
        {
            restauracionFunction();
        }
    }


    public override void fallarFunction()
    {
        referenceHideButton.dejarAveriado();
    }

    public override void restauracionFunction()
    {
        referenceHideButton.activarTodosBotones();
    }
}
