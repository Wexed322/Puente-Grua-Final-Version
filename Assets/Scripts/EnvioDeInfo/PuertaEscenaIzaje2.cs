using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEscenaIzaje2 : MonoBehaviour
{
    public string nombreFile;
    public bool onlyOne;
    public CaidasManager caidasManager;
    public ControlDeCargas controlDeCargasReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sendData();
        }
    }
    public void sendData() 
    {
        if (!onlyOne) 
        {
            ExcelWriter.CreateFile(nombreFile);

            ExcelWriter.WriteCVS("**** ESTADISTICAS EN DEL SEGUNDO NIVEL ****");
            ExcelWriter.WriteCVS(" ");

            ExcelWriter.WriteCVS("**** Tiempo para traslado de las cargas ****");
            ExcelWriter.WriteCVS(controlDeCargasReference.tiempoEnElProceso.ToString());

            ExcelWriter.WriteCVS("**** Numero de caidas de la carga ****");
            ExcelWriter.WriteCVS(caidasManager.contadorCaidas.ToString());

            ExcelWriter.WriteCVS("**** Numero de intentos de izaje con un angulo no adecuado ****");
            ExcelWriter.WriteCVS(controlDeCargasReference.ContadorMalAngulo.ToString());

            ExcelWriter.WriteCVS(" ");


            controlDeCargasReference.deterContador();
            onlyOne = true;
            MenuController.MenuControllerInstance.showFinalScreen();
            //SCREEN FINAL
        }
    }
}
