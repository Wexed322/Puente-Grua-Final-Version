using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
//using Microsoft.Office.Interop.Excel;


public class ExcelWriter : MonoBehaviour
{
    [SerializeField]
    public TextAsset textAssetData;


    //PRUEBA EXPORT EXCEL
    public string fileName;

    void Start()
    {
        fileName = UnityEngine.Application.dataPath + "/test.csv";
        WriteCVS();
    }
    public void WriteCVS() 
    {
        TextWriter tw = new StreamWriter(fileName,false);
        tw.WriteLine("PA;P;P;PASAD;PIPI");
        tw.Close();

        tw = new StreamWriter(fileName, true);
        tw.Close();
    }
}
