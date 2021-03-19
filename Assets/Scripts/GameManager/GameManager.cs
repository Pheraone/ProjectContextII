using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("UI objects")]
    public GameObject pauseObject;
    public GameObject winMenuObject;
    //public GameObject inGameUI;
    public GameObject startObject;

    //[SerializeField] private GameObject[] tutorialText = new GameObject[3];

    internal GameFSM fsm;

    [HideInInspector] public bool IsPaused { get; private set; }

    private void Awake()
    {
        fsm = new GameFSM();
        fsm.Initialize();

        instance = FindObjectOfType<GameManager>();
    }

    public void HandlePause()
    {
        if (fsm.CurrentStateType == GameStateType.Play)
        {
            IsPaused = true;

            Time.timeScale = 1.0f;
            GotoPause();
            return;
        }

        if (fsm.CurrentStateType == GameStateType.Pause || fsm.CurrentStateType == GameStateType.Win)
        {
            Debug.Log("Handling pause");
            IsPaused = false;
            //Player.Instance.enabled = true;
            Time.timeScale = 0f;
            GotoPlay();
        }
    }

    private void Start()
    {
        GoToStart();
    }

    private void Update()
    {
        fsm.UpdateState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePause();
        }
    }
    public void GotoPlay()
    {
        fsm.GotoState(GameStateType.Play);
    }
    public void GotoPause()
    {
        fsm.GotoState(GameStateType.Pause);
    }
    public void GotoWin()
    {
        IsPaused = true;
        //Player.Instance.enabled = false;
        fsm.GotoState(GameStateType.Win);
    }

    public void GoToStart()
    {
        IsPaused = true;
        fsm.GotoState(GameStateType.Start);
    }

    //switch to whatever state the game was previously in
    public void GotoPrevious()
    {
        fsm.GotoState(fsm.PreviousStateType);
    }
}
