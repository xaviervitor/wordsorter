using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    [SerializeField] private ToggleGroup LanguagesGroup;
    [SerializeField] private GameObject LanguageToggleOptionPrefab;

    [SerializeField] private GameObject LevelCompletePanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private Image StarsImage;

    void OnEnable() {
        BoardManager.LevelCompleteEvent += OnLevelComplete;
    }

    void OnDisable() {
        BoardManager.LevelCompleteEvent -= OnLevelComplete;
    }

    void Start() {
        foreach (KeyValuePair<int, string> Language in LocalizationManager.LanguagesDictionary) {
            GameObject LanguageToggleOption = (GameObject) Instantiate(LanguageToggleOptionPrefab, LanguagesGroup.transform);
            LanguageToggleOptionController LanguageToggleOptionController = LanguageToggleOption.GetComponent<LanguageToggleOptionController>();
            LanguageToggleOptionController.ToggleComponent.group = LanguagesGroup;
            
            if (Language.Key == GameState.Language) {
                LanguageToggleOptionController.ToggleComponent.isOn = true;
            }
            LanguageToggleOptionController.ToggleText.text = Language.Value;
        }
    }

    public void OnLevelSelectButtonClick() {
        SceneManager.LoadScene("LevelSelectScene");
    }

    public void OnRestartButtonClick() {
        SceneManager.LoadScene("LevelScene");
    }
    
    public void OnSettingsButtonClick() {
        SettingsPanel.SetActive(true);
    }
    
    public void OnSettingsBackButtonClick() {
        SettingsPanel.SetActive(false);
    }

    public void OnChangeLanguageButtonClick() {
        Toggle SelectedToggle = LanguagesGroup.ActiveToggles().First();
        int NewLanguage = SelectedToggle.transform.GetSiblingIndex();
        if (NewLanguage != GameState.Language) {
            GameState.Language = NewLanguage;
            PlayerPrefs.SetInt(PlayerPrefsStrings.Language, NewLanguage);
            SceneManager.LoadScene("LevelScene");
        }
        SettingsPanel.SetActive(false);
    }

    public void OnLevelComplete(int CurrentLevelIndex) {
        LevelCompletePanel.SetActive(true);
        StarsImage.fillAmount = GameState.GetLevelHighscoreStarFillByIndex(CurrentLevelIndex);
    }
    
    public void OnNextButtonClick() {
        if (GameState.NextLevelIndex + 1 <= Levels.LevelMatrix[GameState.Language].Length - 1) {
            GameState.NextLevelIndex++;
            SceneManager.LoadScene("LevelScene");
        } else {
            SceneManager.LoadScene("LevelSelectScene");
        }
    }
}
