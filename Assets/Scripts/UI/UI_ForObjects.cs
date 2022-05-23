using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ForObjects : MonoBehaviour
{
    public GameObject child;
    public GameObject prefabText;

    public int indice;
    public TextMeshProUGUI[] poolTexts;

    private void Start()
    {
        foreach (var item in poolTexts)
        {
            item.gameObject.SetActive(false);
        }
    }
    /*private GameObject instaces;
    private TextMeshProUGUI textPrefab;
    private RectTransform transformPrefab;*/
    public void overrideText(string text) 
    {
        if(indice > 0)
            poolTexts[indice-1].text = text;
    }
    public void addText(string text) 
    {
        poolTexts[indice].gameObject.SetActive(true);
        poolTexts[indice].text = text;
        indice++;
        indice = indice % poolTexts.Length;
    }

    public void deleteTextsUI() 
    {
        for (int i = 0; i < indice; i++)
        {
            poolTexts[i].gameObject.SetActive(false);
        }
        indice = 0;
    }
}
