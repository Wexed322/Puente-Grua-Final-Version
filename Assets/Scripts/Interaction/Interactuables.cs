using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeInteractionObject { observable, interactuable, both}
public class Interactuables : MonoBehaviour
{
    //protected InteractuableManager interactuableManager;
    protected FirstPersonMovement firstPerson;
    public LayerMask layerInteractuable;
    protected bool enUso;
    protected bool agarrado;
    public int id;
    public TypeInteractionObject myType;
    public void Start()
    {
        //interactuableManager = FindObjectOfType<InteractuableManager>();
        firstPerson = FindObjectOfType<FirstPersonMovement>();
        layerInteractuable = LayerMask.GetMask("Interactuables");
    }

    public virtual void Take() 
    {

    }

    public virtual void Drop()
    {
        this.gameObject.transform.SetParent(null);
    }

    public virtual void Use()
    {

    }

    public virtual void Interaction()
    {

    }

    public virtual void FocusCamera()
    {

    }
    public void putInHand(Transform parent) 
    {
        this.gameObject.transform.position = parent.position;
        this.gameObject.transform.SetParent(parent.transform);
    }

    /*public void examinado() 
    {
        //ver si es nulo
        interactuableManager.paraSerAnotado.Add(this.id);
        interactuableManager.indicesAveriados.Remove(this.id);
    }*/
}
