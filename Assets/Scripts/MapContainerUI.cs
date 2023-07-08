using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class MapContainerUI : MonoBehaviour {
    public GameObject placeholderPrefab;
    public float cellSize;
    private RectTransform rectTransform;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }
    private Vector2 TranslatePosition(Vector2 screenPosition) {
        return screenPosition - rectTransform.anchoredPosition;
    }
    public Placeholder CreatePlaceholder(Color color, Vector2 screenPosition) {
        Placeholder placeholder = Instantiate(placeholderPrefab, gameObject.transform).GetComponent<Placeholder>();
        placeholder.SetColor(color);
        SetPlaceholderPosition(placeholder, screenPosition);
        return placeholder;
    }
    public void SetPlaceholderPosition(Placeholder placeholder, Vector2 screenPosition) {
        Vector2 mapPosition = TranslatePosition(screenPosition);
        placeholder.SetPosition(new Vector2(
            mapPosition.x - (mapPosition.x % cellSize),
            mapPosition.y - (mapPosition.y % cellSize)
        ));
    }
    public void Submit(Placeholder placeholder) {
        Debug.Log("submit");
    }
}
