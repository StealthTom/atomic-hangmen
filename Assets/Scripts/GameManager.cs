using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoSingleton<GameManager> {

    public static List<char> letters = new List<char>{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', };
    public static List<char> _letters;

    public GameObject PlayerNumSelectUI;

    public InterfaceSetup interfaceSetup;

    public WordEntry wordEntry;

    public string[] passwords;

    private static int _playerNum;
    public static int playerNum
    {
        get
        {
            return _playerNum;
        }
        set
        {
            _playerNum = value;
        }
    }

	// Use this for initialization
	void Awake () {
        _playerNum = 0;
        passwords = null;
        StartListening();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(GameState.currentState);
        switch (GameState.currentState)
        {
            case GameState.State.PlayerNumSelect:
                if (playerNum != 0)
                {
                    GameState.RaiseGameStateChange(GameState.State.WordEntry);
                }
                break;

            case GameState.State.WordEntry:
                if(wordEntry.isRunning == false)
                {
                    if(wordEntry.passwords != null)
                    {
                        passwords = wordEntry.passwords;
                        wordEntry.passwords = null;
                    }
                }
                break;

            case GameState.State.Play:

                break;

            case GameState.State.End:

                break;
        }
	}

    void StartListening()
    {
        GameState.GameStateChanged += OnGameStateChanged;
    }

    void StopListening()
    {
        GameState.GameStateChanged -= OnGameStateChanged;
    }

    void OnGameStateChanged(GameState.State prevState, GameState.State newState)
    {
        switch (prevState)
        {
            case GameState.State.None:
                Debug.Log("Leaving None.");
                break;

            case GameState.State.PlayerNumSelect:
                Debug.Log("Leaving PlayerNumSelect.");
                PlayerNumSelectUI.SetActive(false);
                break;

            case GameState.State.WordEntry:
                Debug.Log("Leaving WordEntry.");
                break;
        }

        switch (newState)
        {
            case GameState.State.PlayerNumSelect:
                PlayerNumSelectUI.SetActive(true);
                break;

            case GameState.State.WordEntry:
                wordEntry.gameObject.SetActive(true);
                wordEntry.GetPasswords(playerNum);
                break;
        }
    }
}
