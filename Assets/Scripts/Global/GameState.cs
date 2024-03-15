using System.Collections.Generic;
using UnityEngine;

public static class GameState {
    // Settings
    public static int Language;
    
    // Session
    public static int NextLevelIndex = 0;
    public static int ClearedLevels;
    public static List<int> MovesHighscore = new List<int>();

    public static float GetLevelHighscoreStarFillByIndex(int Index) {
        if (Index > MovesHighscore.Count - 1) return 0.0f;
        return ((float) MovesHighscore[Index]) / 3.0f;
    }
}