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
        prefabSecondCamera = FindObjectOfType<OrbitingCamera>();
    }

    void Update()
    {
        
    }
    public override void FocusCamera()
    {
        prefabSecondCamera.gameObject.SetActive(true);
        prefabSecondCamera.Tarjet = this.gameObject.transform;
    }
}
