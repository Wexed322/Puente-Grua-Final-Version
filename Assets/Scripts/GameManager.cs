using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneEvent
{
    public static System.Action eventsBeforeChangeScene;
    public static System.Action eventsAfterChangeScene;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}
public class GameManager : MonoBehaviour
{
    public List<int> objetosAveriados;
    public static GameManager GameManagerInstance;
    public int frames;

    private void Awake()
    {
        if (GameManagerInstance == null)
        {
            Application.targetFrameRate = frames;
            GameManagerInstance = this;
            DontDestroyOnLoad(GameManagerInstance);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    public void loadNextScene()
    {
        //difuminado
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int indexScene)
    {
        LoadSceneEvent.eventsBeforeChangeScene?.Invoke();
        AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);
        //GameObject sliderCargaObject = menuController.InicializarMenuDeCarga(MenuCargaPrefab);
        //Slider sliderCarga = sliderCargaObject.transform.GetChild(0).gameObject.GetComponent<Slider>();


        while (!op.isDone)
        {
            //op.float = tukson
            yield return null;
        }
        LoadSceneEvent.eventsAfterChangeScene?.Invoke();
    }
    public void exitSimulator() 
    {
        Application.Quit();
    }
}
