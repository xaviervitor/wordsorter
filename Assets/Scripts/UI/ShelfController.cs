using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShelfController : MonoBehaviour {

    public delegate void ShelfClickedDelegate(int SelectedShelfIndex);
    public static event ShelfClickedDelegate ShelfClickedEvent;

    public void OnPointerClick(BaseEventData EventData) {
        if (ShelfClickedEvent != null) {
            ShelfClickedEvent(transform.GetSiblingIndex());
        }
    }
}
