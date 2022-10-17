using UnityEngine;
using UnityEngine.Assertions;

public class MenuController : MonoBehaviour
{
    public static MenuController MenuControllerInstance;
    GameObject panel;
    RectTransform myRectTransform;


    /*COntrol de las pausas*/
    public bool isPaused;


    /*Para mostrar UI de objetos*/
    public UI_ForObjects UI_forObjects;

    /*Control de Menues*/
    public GameObject menuInGame;
    public GameObject menuNormal;

    /*Control de firsPerson*/
    public FirstPersonMovement movimientoPlayer;
    public FirstPersonLook camaraPlayer;
    public bool canPause;

    /*Pantall de GameOver*/
    public GameObject gameOverScreen_;

    /*Pantalla de fin*/
    public GameObject finalScreen_;


    private void Awake()
    {
        if (MenuControllerInstance == null)
        {
            MenuControllerInstance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadSceneEvent.eventsBeforeSceneChange += preserveThroughScenes;
            LoadSceneEvent.eventsAfterSceneChange += startMenuController;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        startMenuController();//ESTO ES UNA FUNCION QUE SE LLAMA EN CADA CAMBIO DE ESCNEA Y DESACTIVA LOS MENUES

        //activamos el menu de start al inicio del juego
        menuNormal.gameObject.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //HASTA ACABAR EL OBSERVE DE LOS OTROS
        {
            PausarYDespausar();
        }

        //if (Input.GetKeyDown(KeyCode.O)) //HASTA ACABAR EL OBSERVE DE LOS OTROS
        //{
        //    menuNormal.gameObject.SetActive(false);
        //}
    }

    public void goToLobby() 
    {
        GameManager.GameManagerInstance.loadScene(0);
        menuNormal.gameObject.gameObject.SetActive(true);
    }
    public void BotonInicioMenu() 
    {
        GameManager.GameManagerInstance.loadNextScene();
    }

    public void BotonSalirMenu()
    {
        GameManager.GameManagerInstance.exitSimulator();
    }
    public void BotonRestartMenu() 
    {
        GameManager.GameManagerInstance.restarScene();
    }

    public void showGameOverScreen() 
    {
        gameOverScreen_.gameObject.SetActive(true);

        this.camaraPlayer.sensitivity = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void showFinalScreen()
    {
        finalScreen_.gameObject.SetActive(true);

        this.camaraPlayer.sensitivity = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        this.movimientoPlayer.enabled = false;
    }
    public void PausarYDespausar() 
    {
        if (isPaused)
        {
            this.camaraPlayer.sensitivity = 2;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            this.camaraPlayer.sensitivity = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        this.movimientoPlayer.enabled = isPaused;
        isPaused = !isPaused;
        menuInGame.SetActive(isPaused);
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

        /*DESACTIVAMOS LOS MENUS*/
        menuInGame.gameObject.SetActive(false);
        menuNormal.gameObject.SetActive(false);

        /*PARA TENER REFERENCIAS A LA HORA DE PAUSAR EL JUEGO*/
        movimientoPlayer = GameObject.FindObjectOfType<FirstPersonMovement>();
        camaraPlayer = GameObject.FindObjectOfType<FirstPersonLook>();
        if (movimientoPlayer != null && camaraPlayer != null) 
        {
            canPause = true;
        }

    }
    public void preserveThroughScenes()
    {
        isPaused = false;
        this.transform.SetParent(GameManager.GameManagerInstance.gameObject.transform); 
    }
}
