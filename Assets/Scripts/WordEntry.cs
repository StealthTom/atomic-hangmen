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
        isRunning = true;
        do
        {
            yield return new WaitForEndOfFrame();
        } while (ConfirmInput() == null);
        passwords[0] = myInputField.text;
        ResetField();
        do
        {
            yield return new WaitForEndOfFrame();
        } while (ConfirmInput() == null);
        passwords[1] = myInputField.text;
        ResetField();
        if (passwords.Count() == 3)
        {
            do
            {
                yield return new WaitForEndOfFrame();
            } while (ConfirmInput() == null);
            passwords[2] = myInputField.text;
            ResetField();
            if (passwords.Count() == 4)
            {
                do
                {
                    yield return new WaitForEndOfFrame();
                } while (ConfirmInput() == null);
                passwords[3] = myInputField.text;
                ResetField();
            }
        }
    }

    public string ConfirmInput()
    {
        if (QueryWord(myInputField.text))
        {
            return myInputField.text;
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
