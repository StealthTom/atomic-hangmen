using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class WordEntry : MonoBehaviour {

    public List<string> words;

    public InputField myInputField;

    public bool isRunning = false;

    public bool entered = false;

    public string[] passwords;

    void Awake()
    {
        var textAsset = Resources.Load("wordlist", typeof(TextAsset)) as TextAsset;
        words = textAsset.text.Split("\n"[0]).ToList();
        for(int count = 0; count < words.Count; count++)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            words[count] = rgx.Replace(words[count], "");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isRunning == true)
        {
            EnterInput();
        }
        if (isRunning == true && passwords[passwords.Length-1] != null)
        {
            isRunning = false;
        }
    }

    public void GetPasswords(int playerNum)
    {
        Debug.Log(playerNum);
        passwords = new string[playerNum];
        Debug.Log("String array initialized");
        if(isRunning == false)
        {
            StartCoroutine(InputCoroutine());
        }
    }

    public IEnumerator InputCoroutine()
    {
        GameManager.instance.interfaceSetup.text.text = "Player 1, enter a word.";
        isRunning = true;
        entered = false;
        do
        {
            yield return new WaitForEndOfFrame();
        } while (entered == false);
        passwords[0] = myInputField.text;
        ResetField();
        entered = false;
        GameManager.instance.interfaceSetup.text.text = "Player 2, enter a word.";
        do
        {
            yield return new WaitForEndOfFrame();
        } while (entered == false);
        passwords[1] = myInputField.text;
        ResetField();
        if (passwords.Count() == 3)
        {
            entered = false;
            GameManager.instance.interfaceSetup.text.text = "Player 3, enter a word.";
            do
            {
                yield return new WaitForEndOfFrame();
            } while (entered == false);
            passwords[2] = myInputField.text;
            ResetField();
            if (passwords.Count() == 4)
            {
                entered = false;
                GameManager.instance.interfaceSetup.text.text = "Player 4, enter a word.";
                do
                {
                    yield return new WaitForEndOfFrame();
                } while (entered == false);
                passwords[3] = myInputField.text;
                ResetField();
                entered = false;
            }
        }
    }

    public string EnterInput()
    {
        Debug.Log("hi");
        if (QueryWord(myInputField.text))
        {
            entered = true;
        }
        return null;
    }

	public bool QueryWord(string s)
    {
        return words.Contains(s);
    }

    public void ResetField()
    {
        myInputField.text = "";
    }
}
