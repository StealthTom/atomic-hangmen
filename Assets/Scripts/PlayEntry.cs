using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayEntry : MonoBehaviour
{

    public InputField myInputField;

    public bool isRunning = false;

    public int currentPlayerIndex;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayerIndex > GameManager.playerNum)
        {
            currentPlayerIndex = 0;
        }
        if (isRunning == true && Input.GetKeyDown(KeyCode.Return))
        {
            if(myInputField.text.Length > 1)
            {
                WordCheck();
            }
            else if(myInputField.text.Length == 1)
            {
                LetterCheck();
            }
        }
    }

    public bool WordCheck()
    {
        if (myInputField.text == GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].word)
        {
            return true;
        }
        return false;
    }

    public void LetterCheck()
    {
        for(int i = 0; i < GameManager.instance.interfaceSetup.currentUI.Count; i++)
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
