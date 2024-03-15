using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordPanelGenerator : MonoBehaviour {
    
    [SerializeField] private GameObject WordPrefab;

    public void Generate(BoardManager BoardManager) {
        foreach (string Word in BoardManager.CurrentLevel.Words) {
            GameObject WordObject = (GameObject) Instantiate(WordPrefab, this.transform);
            TMP_Text WordTextComponent = WordObject.transform.GetChild(0).GetComponent<TMP_Text>();
            WordTextComponent.text = Word;
            BoardManager.AddWord(WordObject);
        }
    }
}
