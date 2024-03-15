using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProgress {
    
    public int ClearedLevels;
    public int[] MovesHighscore;

    public PlayerProgress() {}
    
    public PlayerProgress(int ClearedLevels, int[] MovesHighscore) {
        this.ClearedLevels = ClearedLevels;
        this.MovesHighscore = MovesHighscore;
    }
}