using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Placeholder : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public RectTransform rectTransform;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }
    public void SetColor(Color color) {
        image.color = color;
    }
    public void SetPosition(Vector2 position) {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
    }
}
