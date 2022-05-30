using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaEscenaExaminacion : MonoBehaviour
{
    public string nombreFile;
    public GameObject objetoDondeSeGuardanLosTextosParaExcel;
    public ObjetosAveriadosManager objetosAveriadosManager_;

    public bool onlyOne;
    private void Start()
    {
        objetosAveriadosManager_ = GameManager.GameManagerInstance.GetComponent<ObjetosAveriadosManager>();
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


            ExcelWriter.WriteCVS("**** Objetos examinados por el cliente ****");

            for (int i = 0; i < objetosAveriadosManager_.listaObjetosEXAMINADOS.Count; i++)
            {
                string texto = objetosAveriadosManager_.listaObjetosEXAMINADOS[i].myData.nombre;
                string texto2 = objetosAveriadosManager_.listaObjetosEXAMINADOS[i].myData.falla;
                ExcelWriter.WriteCVS("Nombre del accesorio: " + texto + "  ||  " + "Falla: " + texto2);
            }

            ExcelWriter.WriteCVS(" ");
            ExcelWriter.WriteCVS("**** Objetos NO examinados por el cliente ****");

            for (int i = 0; i < objetosAveriadosManager_.listaObjetosNOEXAMINADOS.Count; i++)
            {
                string texto = objetosAveriadosManager_.listaObjetosNOEXAMINADOS[i].myData.nombre;
                string texto2 = objetosAveriadosManager_.listaObjetosNOEXAMINADOS[i].myData.falla;
                ExcelWriter.WriteCVS("Nombre del accesorio: " + texto + "  ||  " + "Falla: " + texto2);
            }

            ExcelWriter.WriteCVS(" ");
            ExcelWriter.WriteCVS("**** Anotaciones en el CheckList ****");

            for (int i = 0; i < objetoDondeSeGuardanLosTextosParaExcel.transform.childCount; i++)//CARGO LOS TEXTOS EN EL EXCECL
            {
                string texto = objetoDondeSeGuardanLosTextosParaExcel.transform.GetChild(i).GetChild(2).gameObject.GetComponent<Text>().text;
                ExcelWriter.WriteCVS(texto);
            }
            onlyOne = true;
            ExcelWriter.WriteCVS(" ");


            objetosAveriadosManager_.listaObjetosInteractuables.Clear();
            objetosAveriadosManager_.listaObjetosEXAMINADOS.Clear();
            objetosAveriadosManager_.listaObjetosNOEXAMINADOS.Clear();
            GameManager.GameManagerInstance.loadNextScene();
        }
    }
}
