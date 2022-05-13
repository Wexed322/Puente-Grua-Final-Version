using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInteractuable : Interactuables
{
    public new void Start()
    {
        base.Start();
        myType = TypeInteractionObject.interactuable;

    }
    void Update()
    {
        
    }
}
