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
        Debug.Log("CurrentState is " + _currentState + " Changing state to " + newState);
        if (newState == _currentState)
        {

        }
        else if (GameStateChanged != null)
        {
                State prevState = _currentState;
                _currentState = newState;
                GameStateChanged(prevState, newState);
        }
    }

}
