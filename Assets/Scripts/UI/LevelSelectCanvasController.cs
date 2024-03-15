using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectCanvasController : MonoBehaviour {

    [SerializeField] private GameObject ResetProgressPanel;

    public void OnResetProgressButtonClick() {
        ResetProgressPanel.SetActive(true);
    }

    public void OnResetProgressConfirmButtonClick() {
        PlayerProgressManager.ResetPlayerProgress();
        PlayerProgressManager.LoadPlayerProgress();
        SceneManager.LoadScene("LevelSelectScene");
    }

    public void OnResetProgressCloseButtonClick() {
        ResetProgressPanel.SetActive(false);
    }
}
