using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class WordList {

    public static List<string> words;

    public static bool initialized;

	public static void InitializeList()
    {
        var textAsset = Resources.Load("wordlist", typeof(TextAsset)) as TextAsset;
        words = textAsset.text.Split("\n"[0]).ToList();
        for (int count = 0; count < words.Count; count++)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            words[count] = rgx.Replace(words[count], "");
            words[count] = words[count].ToUpper();

        }
        initialized = true;
    }
}
