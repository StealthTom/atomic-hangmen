using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debugger : MonoBehaviour {

    public WordEntry w;
    public Image i;

	public void TestWord(string s)
    {
        if(w.QueryWord(s))
        {
            i.color = new Color(0, 255, 255);
        }
        else
        {
            i.color = new Color(255, 0, 255);
        }
    }
}
