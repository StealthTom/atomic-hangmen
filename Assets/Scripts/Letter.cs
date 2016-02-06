using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Letter : MonoBehaviour {

    public char letter;
    public Text text;
    public bool cycle;
    public int count;

    int betweenCount = 0;

    void Start()
    {
        count = Random.Range(0, GameManager.letters.Count);
        cycle = true;
    }

    void Update()
    {
        if (cycle == true)
        {
            if (betweenCount >= 6)
            {
                text.text = char.ToString(GameManager.letters[count]);
                count++;
                if (count >= GameManager.letters.Count)
                    count = 0;
            }
            else
                betweenCount++;
        }
    }

}
