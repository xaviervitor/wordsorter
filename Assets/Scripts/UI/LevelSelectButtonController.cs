using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectButtonController : MonoBehaviour {
    
    [SerializeField] public TMP_Text ButtonText;
    [SerializeField] public Image StarsImage;
    [SerializeField] public Button MainButton;
    
    public int LevelIndex;

    public void OnLevelSelectButtonClick() {
        GameState.NextLevelIndex = transform.GetSiblingIndex();
        SceneManager.LoadScene("LevelScene");
    }
}
