using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObserveInteractuableManager : MonoBehaviour
{
    public InteractuableObjectObserve[] objetosInteractuables;
    public InteractuableObjectObserve currentInteractuable;
    public OrbitingCamera cameraOrbiting;
    void Start()
    {

    }

    public void FocusCamera(GameObject tarjet)
    {
        cameraOrbiting.activateDesactivateCamera();
        cameraOrbiting.Tarjet = tarjet.transform;
    }
}
