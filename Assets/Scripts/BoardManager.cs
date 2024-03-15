using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardManager : MonoBehaviour {

    public delegate void BlockMovedDelegate(int Moves);
    public static event BlockMovedDelegate BlockMovedEvent;

    public delegate void LevelCompleteDelegate(int CurrentLevelIndex);
    public static event LevelCompleteDelegate LevelCompleteEvent;

    [SerializeField] private WordPanelGenerator WordPanelGenerator;
    [SerializeField] private BoardGenerator BoardGenerator;
    
    private List<GameObject> WordList = new List<GameObject>();
    private List<GameObject> ShelfList = new List<GameObject>();
    private List<Stack<GameObject>> BlockStackList = new List<Stack<GameObject>>();

    public Level CurrentLevel { get; private set; }
    private int CurrentLevelIndex;
    private List<string> BlockWords;
    private int Moves;
    
    private int HighlightedShelfIndex = -1;

    void OnEnable() {
        ShelfController.ShelfClickedEvent += OnShelfClicked;
    }

    void OnDisable() {
        ShelfController.ShelfClickedEvent -= OnShelfClicked;
    }

    void Start() {
        CurrentLevelIndex = GameState.NextLevelIndex;
        CurrentLevel = Levels.LevelMatrix[GameState.Language][CurrentLevelIndex];
        BlockWords = new List<string>(CurrentLevel.BlockWords);
        Moves = 0;

        WordPanelGenerator.Generate(this);
        BoardGenerator.Generate(this);
    }

    public void OnShelfClicked(int SelectedShelfIndex) {
        if (HighlightedShelfIndex == -1) {
            if (BlockStackList[SelectedShelfIndex].Count == 0) return;
            GameObject Block = BlockStackList[SelectedShelfIndex].Peek();
            Block.GetComponent<BlockController>().SetSelectedColor();
            HighlightedShelfIndex = SelectedShelfIndex;
        } else {
            GameObject Block = BlockStackList[HighlightedShelfIndex].Peek();
            if ((HighlightedShelfIndex != SelectedShelfIndex)) {
                if (BlockStackList[SelectedShelfIndex].Count == CurrentLevel.MaxBlocks) return;

                Block.transform.SetParent(ShelfList[SelectedShelfIndex].transform);
                BlockStackList[HighlightedShelfIndex].Pop();
                BlockStackList[SelectedShelfIndex].Push(Block);

                BlockWords[SelectedShelfIndex] += BlockWords[HighlightedShelfIndex][BlockWords[HighlightedShelfIndex].Length - 1];
                BlockWords[HighlightedShelfIndex] = BlockWords[HighlightedShelfIndex].Remove(BlockWords[HighlightedShelfIndex].Length - 1);

                Moves++;
                if (BlockMovedEvent != null) {
                    BlockMovedEvent(Moves);
                }

                CheckWordCompletion();
            }
            Block.GetComponent<BlockController>().SetUnselectedColor();
            HighlightedShelfIndex = -1;
        }
    }

    private void CheckWordCompletion() {
        int SolvedWords = 0;
        for (int i = 0 ; i < CurrentLevel.Words.Length ; i++) {
            if (BlockWords.Contains(CurrentLevel.Words[i])) {
                WordList[i].GetComponent<WordController>().SetSolvedColor();
                SolvedWords++;
            } else {
                WordList[i].GetComponent<WordController>().SetUnsolvedColor();
            }
        }
        if (SolvedWords == CurrentLevel.Words.Length) {
            OnLevelCompleted();
        }
    }

    private void OnLevelCompleted() {
        int Highscore = ComputeHighscore(Moves, Levels.LevelMatrix[GameState.Language][CurrentLevelIndex].MinMoves);
        
        if (GameState.MovesHighscore.Count - 1 < CurrentLevelIndex) {
            GameState.MovesHighscore.Add(Highscore);
            GameState.ClearedLevels++;
        } else if (Highscore > GameState.MovesHighscore[CurrentLevelIndex]) {
            GameState.MovesHighscore[CurrentLevelIndex] = Highscore;
        }
        if (LevelCompleteEvent != null) {
            LevelCompleteEvent(CurrentLevelIndex);
        }
        PlayerProgressManager.SavePlayerProgress();
    }

    private int ComputeHighscore(int Moves, int MinMoves) {
        if (Moves <= MinMoves) {
            return 3;
        } else if (Moves < MinMoves * 3) {
            return 2;
        } else {
            return 1;
        }
    }
    
    public void AddWord(GameObject WordObject) {
        WordList.Add(WordObject);
    }
    
    public void AddShelf(GameObject ShelfObject) {
        ShelfList.Add(ShelfObject);
    }

    public void AddBlockStack(Stack<GameObject> BlockStack) {
        BlockStackList.Add(BlockStack);
    }
}

