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

    public override void Interaction()
    {
        this.firstPerson.enabled = false;
    }

    public override void Drop()
    {
        this.firstPerson.enabled = true;
    }
}
