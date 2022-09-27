using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour
{
    public Container container;
    public string tagContainer;
    public bool dentroContainer;

    void Start()
    {
        tagContainer = container.gameObject.tag;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagContainer))
        {
            if (!dentroContainer)
            {
                container.objetosContenidos.Add(this);

                if (container.objetosContenidos.Count == container.cantidadMaximaParaAccion) 
                {
                    container.reactionAfterBeingFull();
                }
            }
            dentroContainer = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagContainer))
        {
            if (!dentroContainer)
            {
                container.objetosContenidos.Add(this);

                if (container.objetosContenidos.Count == container.cantidadMaximaParaAccion)
                {
                    container.reactionAfterBeingFull();
                }
            }
            dentroContainer = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagContainer))
        {
            if (dentroContainer)
            {
                container.objetosContenidos.Remove(this);
            }
            dentroContainer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagContainer))
        {
            if (dentroContainer)
            {
                container.objetosContenidos.Remove(this);
            }
            dentroContainer = false;
        }
    }
}
