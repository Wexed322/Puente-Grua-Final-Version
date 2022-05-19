using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaEscenaExaminacion : MonoBehaviour
{
    public string nombreFile;
    public GameObject objetoDondeSeGuardanLosTextosParaExcel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            ExcelWriter.CreateFile(nombreFile);
            ExcelWriter.CreateFile(nombreFile);

            ExcelWriter.WriteCVS("**** Anotaciones en el CheckList ****");

            for (int i = 0; i < objetoDondeSeGuardanLosTextosParaExcel.transform.childCount; i++)//CARGO LOS TEXTOS EN EL EXCECL
            {
                string texto = objetoDondeSeGuardanLosTextosParaExcel.transform.GetChild(i).GetChild(2).gameObject.GetComponent<Text>().text;
                ExcelWriter.WriteCVS(texto);
            }
            ExcelWriter.WriteCVS(" ");

            GameManager.GameManagerInstance.loadNextScene();
        }
    }
}
