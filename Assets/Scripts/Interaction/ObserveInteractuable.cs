using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveInteractuable : Interactuables
{
    public OrbitingCamera prefabSecondCamera;


    public AccesoriosData[] listaDeAccesorios;
    public new void Start()
    {
        base.Start();
        myType = TypeInteractionObject.observable;
        //prefabSecondCamera = FindObjectOfType<OrbitingCamera>();
    }

    void Update()
    {

    }

    public override void FocusCamera()
    {
        prefabSecondCamera.activateDesactivateCamera();
        prefabSecondCamera.Tarjet = this.gameObject.transform;
    }

    public override void Drop()
    {
        prefabSecondCamera.activateDesactivateCamera();
        prefabSecondCamera.Tarjet = null;
    }
}
