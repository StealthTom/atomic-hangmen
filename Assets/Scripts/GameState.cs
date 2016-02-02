using UnityEngine;
using System.Collections;

public class GameState : MonoSingleton<GameState> {

    public enum State
    {
        None,
        PlayerNumSelect,
        WordEntry,
        InterfaceSetup,
        Play,
        End
    }

    void Start()
    {
        RaiseGameStateChange(State.PlayerNumSelect);
    }

    private static State _currentState;
    public static State currentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _currentState = value;
        }
    }

    public delegate void GameStateChangeEventHandler(State prevState, State newState);
    public static event GameStateChangeEventHandler GameStateChanged;

    public static void RaiseGameStateChange(State newState)
    {
        State prevState = _currentState;
        _currentState = newState;

        if (GameStateChanged != null)
        {
            GameStateChanged(prevState, newState);
        }
    }

}
