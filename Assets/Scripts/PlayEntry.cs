using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayEntry : MonoBehaviour
{

    public InputField myInputField;

    public bool isRunning = false;

    public int currentPlayerIndex;

    public bool won;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayerIndex > GameManager.playerNum-1)
        {
            currentPlayerIndex = 0;
        }
        if(won == false)
        {
            GameManager.instance.interfaceSetup.text.text = "Player " + (currentPlayerIndex + 1) + " Turn";
        }
        if (isRunning == true && won == false && Input.GetKeyDown(KeyCode.Return))
        {
            if(myInputField.text.Length > 1)
            {
                WordCheck();
                ResetField();
                currentPlayerIndex++;
            }
            else if(myInputField.text.Length == 1)
            {
                LetterCheck();
                ResetField();
                currentPlayerIndex++;
            }
        }
    }

    public bool WordCheck()
    {
        Debug.Log("WordCheck " + myInputField.text);
        if (myInputField.text == GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].word)
        {
            GameManager.instance.interfaceSetup.text.text = "Player " + (currentPlayerIndex + 1) + " Has Won!";
            for (int count = 0; count < GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].letters.Count; count++)
            {
                GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].letters[count].GetComponent<Text>().enabled = true;
            }
                won = true;
            return true;
        }
        return false;
    }

    public void LetterCheck()
    {
        Debug.Log("LetterCheck " + myInputField.text);
        for (int i = 0; i < GameManager.instance.interfaceSetup.currentUI.Count; i++)
        {
            for (int count = 0; count < GameManager.instance.interfaceSetup.currentUI[i].letters.Count; count++)
            {
                if (char.ToString(GameManager.instance.interfaceSetup.currentUI[i].letters[count].letter) == myInputField.text)
                {
                    GameManager.instance.interfaceSetup.currentUI[i].letters[count].GetComponent<Text>().enabled = true;
                }
            }
        }
    }

    public void ResetField()
    {
        myInputField.text = "";
    }
}
