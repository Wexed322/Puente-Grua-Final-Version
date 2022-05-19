using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothInteractuable : Interactuables
{
    public OrbitingCamera prefabSecondCamera;
    public new void Start()
    {
        base.Start();
        myType = TypeInteractionObject.both;
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
        this.transform.SetParent(null);
    }
}
