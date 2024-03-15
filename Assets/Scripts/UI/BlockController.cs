using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour {
    
    [SerializeField] private Image BlockImage;
    
    [SerializeField] private Color UnselectedBlockColor;
    [SerializeField] private Color SelectedBlockColor;

    public void SetSelectedColor() {
        BlockImage.color = SelectedBlockColor;
    }

    public void SetUnselectedColor() {
        BlockImage.color = UnselectedBlockColor;
    }
}
