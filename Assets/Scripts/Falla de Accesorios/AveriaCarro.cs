﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveriaCarro : Averia
{
    public CraneController_ referenceCraneController;
    new void Start()
    {
        base.Start();
        if (this.fallar)
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
        
    }
    public override void restauracionFunction()
    {
        referenceCraneController.gradoDecremento = 0.7f;
        referenceCraneController.gradoIncremento = 0.05f;
        referenceCraneController.maxLength = 100f;
    }
}
