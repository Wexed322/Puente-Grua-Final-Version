using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneEvent
{
    public static System.Action eventsBeforeSceneChange;
    public static System.Action eventsAfterSceneChange;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}
public class GameManager : MonoBehaviour
{
    //public List<string> objetosAveriados;
    public static GameManager GameManagerInstance;
    public SoundManager soundManagerInstance;
    public int frames;

    //Control los menus
    public int EscenaParaActivarMenuGame;


    //Controlar secuencia de niveles
    public int secuencia;//si es 0 es pirque deberia estar en el primer nivel, pero si no estamos es porque estamos testeando una escena aislada

    //Control GAME OVER
    public bool simulationEnd;

    private void Awake()
    {
        if (GameManagerInstance == null)
        {
            Application.targetFrameRate = frames;
            GameManagerInstance = this;
            DontDestroyOnLoad(GameManagerInstance);
            soundManagerInstance = this.GetComponent<SoundManager>();
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public void loadNextScene()
    {
        //difuminado
        secuencia++;
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void loadScene(int index) 
    {
        StartCoroutine(LoadScene(index));
        if (index == 0) 
        {
            secuencia = 0;
        }
    }

    IEnumerator LoadScene(int indexScene)
    {
        LoadSceneEvent.eventsBeforeSceneChange?.Invoke();
        AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);

        while (!op.isDone)
        {
            //op.float = tukson
            yield return null;
        }
        LoadSceneEvent.eventsAfterSceneChange?.Invoke();












        //Cuando Cargo la otra escena
    }
    public void exitSimulator() 
    {
        Application.Quit();
    }

    public void restarScene() 
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
}
