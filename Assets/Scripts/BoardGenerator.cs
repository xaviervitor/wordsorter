using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoardGenerator : MonoBehaviour {
    
    [SerializeField] private GameObject ShelfPrefab;
    [SerializeField] private GameObject BlockPrefab;

    public void Generate(BoardManager BoardManager) {
        foreach (string ShelfString in BoardManager.CurrentLevel.BlockWords) {
            GameObject ShelfObject = (GameObject) Instantiate(ShelfPrefab, this.transform);
            BoardManager.AddShelf(ShelfObject);
            
            Stack<GameObject> BlockStack = new Stack<GameObject>();
            foreach (char BlockChar in ShelfString) {
                GameObject BlockObject = (GameObject) Instantiate(BlockPrefab, ShelfObject.transform);
                TMP_Text BlockTextComponent = BlockObject.transform.GetChild(0).GetComponent<TMP_Text>();
                BlockTextComponent.text = BlockChar.ToString();
                BlockStack.Push(BlockObject);
            }
            BoardManager.AddBlockStack(BlockStack);
        }
    }
}
