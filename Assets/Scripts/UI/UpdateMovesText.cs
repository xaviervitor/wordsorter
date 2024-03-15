using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMovesText : MonoBehaviour {
    
    [SerializeField] private TMP_Text MovesText;

    void OnEnable() {
        BoardManager.BlockMovedEvent += OnBlockMoved;
    }

    void OnDisable() {
        BoardManager.BlockMovedEvent -= OnBlockMoved;
    }

    void OnBlockMoved(int Moves) {
        MovesText.text = Moves.ToString();
    }
}
