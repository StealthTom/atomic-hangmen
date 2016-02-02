using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InterfaceSetup : MonoBehaviour {

    public Transform[] twoPlayerPoints;
    public Transform[] threePlayerPoints;
    public Transform[] fourPlayerPoints;

    public float xOffset;

    public Player playerInterface;
    public GameObject letter;

    public List<Player> currentUI;

    public bool setup;

    public Text text;

    public Transform playerParent;

    public List<Player> SetupUI(int playerNum)
    {
        if(currentUI.Count != 0)
        {
            DestroyUI();
        }
        switch (playerNum)
        {
            case 2:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.transform.SetParent(playerParent);
                    _temp.position = twoPlayerPoints[count].position;
                    _temp.localScale = new Vector3(1, 1, 1);
                    currentUI.Add(_temp.GetComponent<Player>());
                    setup = true;
                }
                return currentUI;

            case 3:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.transform.SetParent(playerParent);
                    _temp.position = threePlayerPoints[count].position;
                    _temp.localScale = new Vector3(1, 1, 1);
                    currentUI.Add(_temp.GetComponent<Player>());
                    setup = true;
                }
                return currentUI;

            case 4:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.transform.SetParent(playerParent);
                    _temp.position = fourPlayerPoints[count].position;
                    _temp.localScale = new Vector3(1,1,1);
                    currentUI.Add(_temp.GetComponent<Player>());
                    setup = true;
                }
                return currentUI;
        }
        return null;
    }

    public void SetupLetterBlanks()
    {
        for(int count = 0; count < currentUI.Count; count++)
        {
            float dist = 0;
            if(currentUI[count].word.Length%2 == 0)
            {
                dist = currentUI[count].word.Length / 2 * xOffset;
            }
            else
            {
                dist = (currentUI[count].word.Length / 2 * xOffset) - (xOffset/2);
            }
            for(int i = 0; i < currentUI[count].word.Length; i++)
            {
                GameObject g = Instantiate(letter);
                g.transform.SetParent(currentUI[count].transform);
                g.transform.localPosition = new Vector3(-dist + (i * xOffset),0,0);
                g.GetComponent<Letter>().letter = currentUI[count].word[i];
                g.GetComponent<Text>().text = char.ToString(g.GetComponent<Letter>().letter);
                g.GetComponent<Text>().enabled = false;
                currentUI[count].letters.Add(g.GetComponent<Letter>());
            }
        }
    }

    public void DestroyUI()
    {
        for (int count = 0; count < currentUI.Count; count++)
        {
            Destroy(currentUI[count]);
        }
        currentUI.Clear();
    }
}
