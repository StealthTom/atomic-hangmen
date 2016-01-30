using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InterfaceSetup : MonoBehaviour {

    public Transform[] twoPlayerPoints;
    public Transform[] threePlayerPoints;
    public Transform[] fourPlayerPoints;

    public Player playerInterface;

    public List<Player> currentUI;

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
                    _temp.position = twoPlayerPoints[count].position;
                    currentUI.Add(_temp.GetComponent<Player>());
                }
                return currentUI;

            case 3:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.position = threePlayerPoints[count].position;
                    currentUI.Add(_temp.GetComponent<Player>());
                }
                return currentUI;

            case 4:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.position = fourPlayerPoints[count].position;
                    currentUI.Add(_temp.GetComponent<Player>());
                }
                return currentUI;
        }
        return null;
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
