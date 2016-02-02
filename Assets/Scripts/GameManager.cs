﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoSingleton<GameManager> {

    public static List<char> letters = new List<char>{'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', };
    public static List<char> _letters;

    public GameObject PlayerNumSelectUI;

    public InterfaceSetup interfaceSetup;

    public WordEntry wordEntry;
    public PlayEntry playEntry;

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
                        GameState.RaiseGameStateChange(GameState.State.InterfaceSetup);
                    }
                }
                break;

            case GameState.State.InterfaceSetup:
                if(interfaceSetup.setup == true)
                {
                    GameState.RaiseGameStateChange(GameState.State.Play);
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
                wordEntry.enabled = false;
                wordEntry.gameObject.SetActive(false);
                break;

            case GameState.State.InterfaceSetup:
                Debug.Log("Leaving InterfaceSetup.");
                break;

            case GameState.State.Play:
                Debug.Log("Leaving Play.");
                interfaceSetup.gameObject.SetActive(false);
                playEntry.enabled = true;
                playEntry.gameObject.SetActive(true);
                break;

            case GameState.State.End:
                Debug.Log("Leaving End.");
                break;

        }

        switch (newState)
        {
            case GameState.State.None:
                Debug.LogError("Error, state has become none.");
                break;

            case GameState.State.PlayerNumSelect:
                PlayerNumSelectUI.SetActive(true);
                break;

            case GameState.State.WordEntry:
                wordEntry.gameObject.SetActive(true);
                wordEntry.enabled = true;
                wordEntry.GetPasswords(playerNum);
                break;

            case GameState.State.InterfaceSetup:
                interfaceSetup.gameObject.SetActive(true);
                interfaceSetup.SetupUI(playerNum);
                List<int> nums = new List<int> { };
                for (int count = 0; count < playerNum; count++)
                {
                    nums.Add(count + 1);
                }
                if (playerNum == 2)
                {
                    nums.Remove(1);
                    int _rand = Random.Range(0, nums.Count);
                    interfaceSetup.currentUI[0].word = passwords[nums[_rand - 1]];
                    interfaceSetup.currentUI[_rand - 1].word = passwords[0];
                }
                if (playerNum == 3)
                {
                    nums.Remove(1);
                    int _rand = Random.Range(0, nums.Count);
                    interfaceSetup.currentUI[0].word = passwords[nums[_rand] - 1];
                    Player _i = interfaceSetup.currentUI[nums[_rand] - 1];
                    nums.Remove(nums[_rand]);
                    _i.word = passwords[nums[0] - 1];
                    interfaceSetup.currentUI[nums[0] - 1].word = passwords[0];
                }
                if (playerNum == 4)
                {
                    nums.Remove(1);
                    int _rand = Random.Range(0, nums.Count);
                    interfaceSetup.currentUI[0].word = passwords[nums[_rand - 1]];
                    interfaceSetup.currentUI[_rand - 1].word = passwords[0];
                    nums.Remove(nums[_rand]);
                    int _secondRand = Random.Range(0, nums.Count);
                    nums.Remove(nums[_secondRand]);
                    interfaceSetup.currentUI[_secondRand].word = passwords[nums[0]];
                    interfaceSetup.currentUI[nums[0]].word = passwords[_secondRand];
                }
                interfaceSetup.SetupLetterBlanks();
                break;

            case GameState.State.Play:
                playEntry.gameObject.SetActive(true);
                playEntry.enabled = true;
                break;

            case GameState.State.End:
                break;
        }
    }
}
