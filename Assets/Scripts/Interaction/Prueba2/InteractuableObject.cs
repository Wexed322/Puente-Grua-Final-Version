using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeInteractionObject {interactuable, observable, both }
public enum TextUI {Tomar, Examinar, Usar, Soltar}
public class InteractuableObject : MonoBehaviour
{
    protected FirstPersonMovement movimientoPlayer;
    protected FirstPersonLook camaraPlayer;

    public bool enUso_;
    public TypeInteractionObject myType;
    public AccesoriosData myData;
    public void Start()
    {
        camaraPlayer = FindObjectOfType<FirstPersonLook>();
        movimientoPlayer = FindObjectOfType<FirstPersonMovement>();
        enUso_ = false;
    }

    void Update()
    {
        
    }

    public virtual void FirstActionWith()//OBSERVE
    {

    }

    public virtual void FirstActionWith(Transform padre)//PARA COGER
    {
        this.transform.position = padre.position;
        this.transform.SetParent(padre);
    }

    public virtual void UsarObject()
    {

    }

    public virtual void drop()
    {

    }

    public virtual void dropKeepParent()
    {
 
    }

    public virtual void take()
    {

    }
    public void watchObject()
    {


    }
}
