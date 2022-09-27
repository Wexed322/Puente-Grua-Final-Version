using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaEscenaExaminacion : MonoBehaviour
{
    //EXCEL
    public string nombreFile;
    public GameObject objetoDondeSeGuardanLosTextosParaExcel;
    public ObjetosAveriadosManager objetosAveriadosManager_;

    public bool onlyOne;
    private void Start()
    {
        objetosAveriadosManager_ = GetComponent<ObjetosAveriadosManager>();
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.B))
            objetosAveriadosManager_.filterExaminedObjects();*/
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && onlyOne == false)
        {
            objetosAveriadosManager_.filterExaminedObjects();
            ExcelWriter.CreateFile(nombreFile);


            ExcelWriter.WriteCVS("**** OBJETOS EXAMINADOS POR EL CLIENTE ****");

            for (int i = 0; i < objetosAveriadosManager_.listaObjetosEXAMINADOS.Count; i++)
            {
                string texto = objetosAveriadosManager_.listaObjetosEXAMINADOS[i].myData.nombre;
                string texto2 = objetosAveriadosManager_.listaObjetosEXAMINADOS[i].myData.falla;
                ExcelWriter.WriteCVS("Nombre del accesorio: " + texto + "  ||  " + "Falla: " + texto2);
            }

            ExcelWriter.WriteCVS(" ");
            ExcelWriter.WriteCVS("**** OBJETOS NO EXAMINADOS POR EL CLIENTE ****");

            for (int i = 0; i < objetosAveriadosManager_.listaObjetosNOEXAMINADOS.Count; i++)
            {
                string texto = objetosAveriadosManager_.listaObjetosNOEXAMINADOS[i].myData.nombre;
                string texto2 = objetosAveriadosManager_.listaObjetosNOEXAMINADOS[i].myData.falla;
                ExcelWriter.WriteCVS("Nombre del accesorio: " + texto + "  ||  " + "Falla: " + texto2);
            }

            ExcelWriter.WriteCVS(" ");
            ExcelWriter.WriteCVS("**** ANOTACIONES EN EL CHECKLIST ****");

            for (int i = 0; i < objetoDondeSeGuardanLosTextosParaExcel.transform.childCount; i++)//CARGO LOS TEXTOS EN EL EXCECL
            {
                string texto = objetoDondeSeGuardanLosTextosParaExcel.transform.GetChild(i).GetChild(2).gameObject.GetComponent<Text>().text;
                ExcelWriter.WriteCVS(texto);
            }
            ExcelWriter.WriteCVS(" ");

            objetosAveriadosManager_.listaObjetosInteractuables.Clear();
            objetosAveriadosManager_.listaObjetosEXAMINADOS.Clear();
            objetosAveriadosManager_.listaObjetosNOEXAMINADOS.Clear();

            onlyOne = true;
            GameManager.GameManagerInstance.loadNextScene();
        }
    }
}
