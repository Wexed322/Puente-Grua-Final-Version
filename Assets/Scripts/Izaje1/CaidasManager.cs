using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidasManager : MonoBehaviour
{
    public string tagDeObjetoACaer;
    public int contadorCaidas;
    public bool seCuentaComoCaida;
    void Start()
    {
        seCuentaComoCaida = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagDeObjetoACaer))
        {
            if (seCuentaComoCaida)
            {
                StartCoroutine(seCayoBobina());
            }
        }
    }

    IEnumerator seCayoBobina() 
    {
        contadorCaidas++;
        seCuentaComoCaida = false;
        yield return new WaitForSeconds(20);
        seCuentaComoCaida = true;
    }

}
