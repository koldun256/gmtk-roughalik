using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class RoomContainerUI : MonoBehaviour {
    public float cellSize;
    private RectTransform rectTransform;
    public int id = 0;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
        cellSize = rectTransform.rect.width / 6;
    }
    public Vector3[] GetCorners() {
        Vector3[] v = new Vector3[4];
        rectTransform.GetWorldCorners(v);
        return v;
    }
    public Vector2 TranslatePosition(Vector2 screenPosition) {
        Vector2 bottomLeft = GetCorners()[0];
        return screenPosition - bottomLeft;
    }
    public Vector2 SnapPosition(Vector2 localPosition) {
        return new Vector2(
            localPosition.x - (localPosition.x % cellSize),
            localPosition.y - (localPosition.y % cellSize)
        );
    }
    public void Attach(GameObject card) {
        RectTransform cardTransform = card.GetComponent<RectTransform>();
        Vector2 originalWorldPosition = cardTransform.anchoredPosition;
        cardTransform.parent = gameObject.transform;
        cardTransform.anchorMin = Vector2.zero;
        cardTransform.anchorMax = Vector2.zero;
        cardTransform.anchoredPosition = SnapPosition(TranslatePosition(originalWorldPosition));
        cardTransform.sizeDelta = new Vector2(cellSize, cellSize);
    }
}
