using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideButton : MonoBehaviour
{
    [Header("--- Control de botones ---")]
    public BotonesBotonera ReferencebotonesFuncionales;
    public List<GameObject> botonesGO;

    void Start()
    {
        //Desactivar botones

        if (SceneManager.GetActiveScene().name == "Examinacion")
        {
            ReferencebotonesFuncionales.desactivamosBotones = false;//Reiniciar config
            ReferencebotonesFuncionales.botonesFuncionales.Clear();//Reiniciar config

            for (int i = 0; i < 8; i++)
            {
                if (i != 0)
                {
                    int random = Random.Range(0, 100);
                    if (random % 2 == 0)
                    {
                        botonesGO[i].gameObject.SetActive(true);
                        ReferencebotonesFuncionales.botonesFuncionales.Add(true);
                    }
                    else
                    {
                        botonesGO[i].gameObject.SetActive(false);
                        ReferencebotonesFuncionales.botonesFuncionales.Add(false);
                    }
                }
                else 
                {
                    botonesGO[i].gameObject.SetActive(true);
                    ReferencebotonesFuncionales.botonesFuncionales.Add(true);
                }
                
            }
            ReferencebotonesFuncionales.desactivamosBotones = true;
        }
    }


    public void activarTodosBotones() 
    {
        ReferencebotonesFuncionales.botonesFuncionales.Clear();
        for (int i = 0; i < 8; i++)
        {
            botonesGO[i].gameObject.SetActive(true);
            ReferencebotonesFuncionales.botonesFuncionales.Add(true);
        }
    }

    public void dejarAveriado() 
    {
        if (ReferencebotonesFuncionales.desactivamosBotones)
        {
            for (int i = 0; i < ReferencebotonesFuncionales.botonesFuncionales.Count; i++)
            {
                botonesGO[i].gameObject.SetActive(ReferencebotonesFuncionales.botonesFuncionales[i]);
            }
        }
    }
}
