using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {
    
    public int MaxBlocks;
    public int MinMoves;
    public string[] Words;
    public string[] BlockWords;

    public Level(int MaxBlocks, int MinMoves, string[] Words, string[] BlockWords) {
        this.MaxBlocks = MaxBlocks;
        this.MinMoves = MinMoves;
        this.Words = Words;
        this.BlockWords = BlockWords;
    }
}