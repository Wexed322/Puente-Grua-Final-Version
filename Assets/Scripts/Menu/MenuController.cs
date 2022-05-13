﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController MenuControllerInstance;
    GameObject panel;
    RectTransform myRectTransform;
    private void Awake()
    {
        if (MenuControllerInstance == null)
        {
            MenuControllerInstance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadSceneEvent.eventsBeforeChangeScene += preserveThroughScenes;
            LoadSceneEvent.eventsAfterChangeScene += startMenuController;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        startMenuController();
    }
    public void BotonInicioMenu() 
    {
        GameManager.GameManagerInstance.loadNextScene();
    }

    public void BotonSalirMenu()
    {
        GameManager.GameManagerInstance.exitSimulator();
    }

    void startMenuController() 
    {
        myRectTransform = GetComponent<RectTransform>();
        panel = GameObject.FindGameObjectWithTag("Panel");
        if (panel != null)
        {
            this.transform.SetParent(panel.transform);
            myRectTransform.localPosition = new Vector2(0, 0);
            myRectTransform.sizeDelta = new Vector2(0, 0);
            myRectTransform.localScale = new Vector2(1, 1);

        }
    }
    public void preserveThroughScenes()
    {
        this.transform.SetParent(GameManager.GameManagerInstance.gameObject.transform); 
    }
}