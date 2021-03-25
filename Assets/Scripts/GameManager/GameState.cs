﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStateType { Start, Play, Pause, Win }

public abstract class GameState 
{
    protected GameFSM owner;
    protected GameManager gameManager;

    public void Initialize(GameFSM owner)
    {
        this.owner = owner;
        gameManager = owner.owner;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class StartState : GameState
{
    public override void Enter()
    {
        //open pause menu, freeze game, unlock cursor
        GameManager.Instance.startObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public override void Update()
    {
     
    }
    public override void Exit()
    {
        GameManager.Instance.startObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
    }
}

public class PlayState : GameState
{
    public override void Enter()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1.0f;

    }
    public override void Update()
    {

    }
    public override void Exit()
    {

    }
}
public class PauseState : GameState
{
    public override void Enter()
    {
        //open pause menu, freeze game, unlock cursor
        GameManager.Instance.pauseObject.SetActive(true);
        GameManager.Instance.inGameUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public override void Update()
    {

    }
    public override void Exit()
    {
        GameManager.Instance.pauseObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
public class WinState : GameState
{
    public override void Enter()
    {
        GameManager.Instance.winMenuObject.SetActive(true);
        GameManager.Instance.inGameUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        Debug.Log("entering win state");
        Player.Instance.score = 0;
    }
    public override void Update()
    {
        
    }
    public override void Exit()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Exiting win state");

        GameManager.Instance.winMenuObject.SetActive(false);
    }
}
