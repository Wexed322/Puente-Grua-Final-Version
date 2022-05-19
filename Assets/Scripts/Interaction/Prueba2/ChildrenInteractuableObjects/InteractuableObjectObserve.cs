using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableObjectObserve : InteractuableObject
{
    public OrbitingCamera cameraOrbiting;
    public Transform pivoteParaCamara;
    new void Start()
    {
        base.Start();
        this.myType = TypeInteractionObject.observable;
        //cameraOrbiting = FindObjectOfType<OrbitingCamera>();
        if (pivoteParaCamara == null) //VERIFCAMOS SI TIENE UN PIVOTE POR DEFECTO
        {
            pivoteParaCamara = this.gameObject.transform;
        }
    }
        
    public override void FirstActionWith()
    {
        FocusCamera(pivoteParaCamara);
    }

    public override void drop()
    {
        cameraOrbiting.Tarjet = null;
        cameraOrbiting.activateDesactivateCamera();
    }

    public void FocusCamera(Transform tarjet)
    {
        cameraOrbiting.activateDesactivateCamera();
        cameraOrbiting.Tarjet = tarjet;
    }

}
