using UnityEngine;
using System.Collections;

public class PlayerNumSelect : MonoBehaviour {

    public void PlayerNumberSelect(int num)
    {
        GameManager.playerNum = num;
    }

}
