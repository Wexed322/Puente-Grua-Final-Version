﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuableManager : MonoBehaviour
{
    public Interactuables[] objetosAveriados;//añadir drag n drop
    public List<int> indicesAveriados;
    public List<int> paraSerAnotado;



    //TEST
    public string prueba;
    void Start()
    {
        foreach (Interactuables item in objetosAveriados)
        {
            indicesAveriados.Add(item.id);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            ConcuerdaConBaseDatos(prueba);
        }
    }

    public void ConcuerdaConBaseDatos(string input) 
    {
        for (int i = 0; i < paraSerAnotado.Count; i++)
        {
            //Debug.Log(excelReader.palabrasClave2[paraSerAnotado[i]].Length);
        }
    }
}