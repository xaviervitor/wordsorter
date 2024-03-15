using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordController : MonoBehaviour {
    
    [SerializeField] private Image WordImage;
    
    [SerializeField] private Color UnsolvedWordColor;
    [SerializeField] private Color SolvedWordColor;

    public void SetSolvedColor() {
        WordImage.color = SolvedWordColor;
    }

    public void SetUnsolvedColor() {
        WordImage.color = UnsolvedWordColor;
    }
}
