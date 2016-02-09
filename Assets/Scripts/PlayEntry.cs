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
        if(GameManager.playerNum == 2)
        {
            GameManager.instance.interfaceSetup.text.transform.position = GameManager.instance.interfaceSetup.twoPlayerPoints[currentPlayerIndex].position;
            myInputField.transform.position = GameManager.instance.interfaceSetup.twoPlayerPoints[currentPlayerIndex].position;
            GameManager.instance.interfaceSetup.text.transform.position = new Vector2(GameManager.instance.interfaceSetup.text.transform.position.x, GameManager.instance.interfaceSetup.text.transform.position.y-100);
        }
        else if (GameManager.playerNum == 3)
        {
            GameManager.instance.interfaceSetup.text.transform.position = GameManager.instance.interfaceSetup.threePlayerPoints[currentPlayerIndex].position;
            myInputField.transform.position = GameManager.instance.interfaceSetup.threePlayerPoints[currentPlayerIndex].position;
            GameManager.instance.interfaceSetup.text.transform.position = new Vector2(GameManager.instance.interfaceSetup.text.transform.position.x, GameManager.instance.interfaceSetup.text.transform.position.y - 100);
        }
        else if (GameManager.playerNum == 4)
        {
            GameManager.instance.interfaceSetup.text.transform.position = GameManager.instance.interfaceSetup.fourPlayerPoints[currentPlayerIndex].position;
            myInputField.transform.position = GameManager.instance.interfaceSetup.fourPlayerPoints[currentPlayerIndex].position;
            GameManager.instance.interfaceSetup.text.transform.position = new Vector2(GameManager.instance.interfaceSetup.text.transform.position.x, GameManager.instance.interfaceSetup.text.transform.position.y - 100);
        }
        if (won == false)
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
        if (myInputField.text.ToUpper() == GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].word)
        {
            GameManager.instance.interfaceSetup.text.text = "Player " + (currentPlayerIndex + 1) + " Has Won!";
            for (int count = 0; count < GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].letters.Count; count++)
            {
                GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].letters[count].GetComponent<Text>().enabled = true;
                GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].letters[count].cycle = false;
                GameManager.instance.interfaceSetup.currentUI[currentPlayerIndex].letters[count].GetComponent<Text>().text = char.ToString(myInputField.text[count]);
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
                if (char.ToString(GameManager.instance.interfaceSetup.currentUI[i].letters[count].letter) == myInputField.text.ToUpper())
                {
                    GameManager.instance.interfaceSetup.currentUI[i].letters[count].GetComponent<Text>().enabled = true;
                    GameManager.instance.interfaceSetup.currentUI[i].letters[count].cycle = false;
                    GameManager.instance.interfaceSetup.currentUI[i].letters[count].GetComponent<Text>().text = myInputField.text;
                }
            }
        }
    }

    public void ResetField()
    {
        myInputField.text = "";
    }
}
