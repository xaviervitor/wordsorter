using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelGridGenerator : MonoBehaviour {
    
    [SerializeField] private GameObject LevelSelectButtonPrefab;

    void Start() {
        Generate();    
    }

    private void Generate() {
        for (int i = 0 ; i < Levels.LevelMatrix[GameState.Language].Length ; i++) {
            
            GameObject LevelSelectButton = (GameObject) Instantiate(LevelSelectButtonPrefab, this.transform);
            LevelSelectButtonController LevelSelectButtonController = LevelSelectButton.GetComponent<LevelSelectButtonController>();
            LevelSelectButtonController.ButtonText.text = (i + 1).ToString();
            
            if (i < GameState.ClearedLevels + 1) {
                LevelSelectButtonController.LevelIndex = i;
                LevelSelectButtonController.StarsImage.fillAmount = GameState.GetLevelHighscoreStarFillByIndex(i);
            } else {
                LevelSelectButtonController.MainButton.interactable = false;
            }
        }
    }
}
