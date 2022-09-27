using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ExcelWriter : MonoBehaviour
{
    private static TextWriter tw;
    private static string path;
    private static string nombreFile;
    void Start()
    {
        nombreFile = "";
    }
    public static void WriteCVS(string accesorios)
    {
        tw = new StreamWriter(path, true);//abrir el documento
        tw.WriteLine(accesorios);// calls continuos en una misma linea no hara saltos
        tw.Close();
    }

    public static void CreateFile(string nombreFileInput)
    {
        if (nombreFile != nombreFileInput)
        {
            /*path = UnityEngine.Application.dataPath + "\\Excels";
            nombreFile = nombreFileInput;
            StringBuilder cvscontent = new StringBuilder();//para usar strings de forma no tan costosa para el sistema, por la expliocacion de nilton porque en relaidad se podria poner un string normal y tambien funiona pero boe
            path +=  string.Format("\\{0}.csv", nombreFileInput);

            File.AppendAllText(path, cvscontent.ToString());

            tw = new StreamWriter(path, false);//borrar lo que había anteriormente 
            tw.Close();*/



            nombreFile = nombreFileInput;
            StringBuilder cvscontent = new StringBuilder();//para usar strings de forma no tan costosa para el sistema, por la expliocacion de nilton porque en relaidad se podria poner un string normal y tambien funiona pero boe


            Directory.CreateDirectory(Application.streamingAssetsPath + "\\Excel_Analisis");


            path = Path.Combine(Application.streamingAssetsPath, "\\Excel_Analisis", string.Format("\\{0}.csv", nombreFileInput));

            File.AppendAllText(path, cvscontent.ToString());

            tw = new StreamWriter(path, false);//borrar lo que había anteriormente 
            tw.Close();
        }
    }
}

