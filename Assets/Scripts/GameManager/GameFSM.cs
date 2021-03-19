using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFSM 
{
    public GameManager owner;

    private Dictionary<GameStateType, GameState> states;

    public GameStateType CurrentStateType { get; private set; }
    public GameStateType PreviousStateType { get; private set; }

    private GameState currentState;
    private GameState previousState;

    public void Initialize()
    {
        states = new Dictionary<GameStateType, GameState>();


        states.Add(GameStateType.Start, new StartState());
        states.Add(GameStateType.Play, new PlayState());
        states.Add(GameStateType.Pause, new PauseState());
        states.Add(GameStateType.Win, new WinState());
    }

    public void UpdateState()
    {
        currentState?.Update();
    }

    public void GotoState(GameStateType key)
    {
        if (!states.ContainsKey(key))
        {
            return;
        }

        currentState?.Exit();

        previousState = currentState;
        PreviousStateType = CurrentStateType;

        CurrentStateType = key;
        currentState = states[CurrentStateType];

        currentState.Enter();
    }

    public GameState GetState(GameStateType type)
    {
        if (!states.ContainsKey(type))
        {
            return null;
        }
        return states[type];
    }
}
