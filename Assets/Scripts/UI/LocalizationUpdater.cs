using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class LocalizationUpdater : MonoBehaviour {
    
    [SerializeField] private List<TMP_Text> LocalizedTMPTextObjects;

    void Start() {
        foreach (TMP_Text TextObject in LocalizedTMPTextObjects) {
            TextObject.text = LocalizationManager.StringsDictionary[GameState.Language][TextObject.name];
        }
	}
}