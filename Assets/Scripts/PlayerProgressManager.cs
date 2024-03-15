using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressManager : MonoBehaviour {
    // Singleton
    public static PlayerProgressManager instance = null;

    private static string PlayerProgressFileName = "PlayerProgress.json";
    
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

    void Init() {
        LoadPlayerProgress();
    }

    void Start() {
        LoadPlayerPrefs();
    }

    void LoadPlayerPrefs() {
        if (!PlayerPrefs.HasKey(PlayerPrefsStrings.Language)) {
            int FirstLanguage = LocalizationManager.LanguagesDictionary.Keys.First();
            PlayerPrefs.SetInt(PlayerPrefsStrings.Language, FirstLanguage);
        }
        GameState.Language = PlayerPrefs.GetInt(PlayerPrefsStrings.Language);
    }

    public static void SavePlayerProgress() {
        string FilePath = Application.persistentDataPath + "/" + PlayerProgressFileName;
        PlayerProgress PlayerProgress = new PlayerProgress(
            GameState.ClearedLevels,
            GameState.MovesHighscore.ToArray()
        );
        string SerializedPlayerProgress = JsonUtility.ToJson(PlayerProgress);
        File.WriteAllText(FilePath, SerializedPlayerProgress);
    }

    public static void LoadPlayerProgress() {
        string FilePath = Application.persistentDataPath + "/" + PlayerProgressFileName;
        if (File.Exists(FilePath)) {
            string SerializedPlayerProgress = File.ReadAllText(FilePath);
            PlayerProgress PlayerProgress = JsonUtility.FromJson<PlayerProgress>(SerializedPlayerProgress);
            GameState.ClearedLevels = PlayerProgress.ClearedLevels;
            GameState.MovesHighscore = new List<int>(PlayerProgress.MovesHighscore);
        }
    }

    public static void ResetPlayerProgress() {
        string FilePath = Application.persistentDataPath + "/" + PlayerProgressFileName;
        PlayerProgress PlayerProgress = new PlayerProgress();
        string SerializedPlayerProgress = JsonUtility.ToJson(PlayerProgress);
        File.WriteAllText(FilePath, SerializedPlayerProgress);
    }
}
