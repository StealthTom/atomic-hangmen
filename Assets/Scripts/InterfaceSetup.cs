using UnityEngine;
using System.Collections;

public class InterfaceSetup : MonoBehaviour {

    public Transform[] twoPlayerPoints;
    public Transform[] threePlayerPoints;
    public Transform[] fourPlayerPoints;

    public GameObject playerInterface;

    public bool SetupUI(int playerNum)
    {
        switch (playerNum)
        {
            case 2:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.position = twoPlayerPoints[count].position;
                }
                return true;

            case 3:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.position = threePlayerPoints[count].position;
                }
                return true;

            case 4:
                for (int count = 0; count < playerNum; count++)
                {
                    Transform _temp = Instantiate(playerInterface).GetComponent<Transform>();
                    _temp.position = fourPlayerPoints[count].position;
                }
                return true;
        }
        return false;
    }
}
