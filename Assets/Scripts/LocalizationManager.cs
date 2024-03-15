using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class LocalizationManager : MonoBehaviour {
    // Singleton
    public static LocalizationManager instance = null;
    
    void Awake() {
		if (instance == null) {
			instance = this;
            Init();
			DontDestroyOnLoad(gameObject);
		} else if (instance != this) {
            Destroy(gameObject);
		}
	}
    // Singleton
    
    public static Dictionary<int, string> LanguagesDictionary = new Dictionary<int,  string>();
    public static Dictionary<int, Dictionary<string, string>> StringsDictionary = new Dictionary<int, Dictionary<string, string>>();
    
    // Reads the localization table file assuming the structure:
    // +---------+---------+---------+
    // |*Ignored*|Language1|Language2|
    // |TextKey1 |Text     |Text     |
    // |TextKey2 |Text     |Text     |
    // +---------+---------+---------+
    void Init() {
        string LocalizationTableString = Resources.Load<TextAsset>("LocalizationTable").text;
        string[] Records = LocalizationTableString.Split("\n");
        
        // Populate LanguagesDictionary and instantiate StringsDictionary indexes based on the first line
        string[] Fields = Records[0].Split(",");
        for (int i = 1 ; i < Fields.Length ; i++) {
            LanguagesDictionary.Add(i - 1, Fields[i]);
            StringsDictionary.Add(i - 1, new Dictionary<string, string>());
        }
        
        for (int j = 1 ; j < Records.Length ; j++) {
            Fields = Records[j].Split(",");
            
            for (int i = 1 ; i < Fields.Length ; i++) {
                StringsDictionary[i - 1].Add(Fields[0], Fields[i]);
            }
        }
    }
}