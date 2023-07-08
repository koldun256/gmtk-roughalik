using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class RoomContainerUI : MonoBehaviour {
    public GameObject placeholderPrefab;
    public float cellSize;
    private RectTransform rectTransform;
    private MapData mapData;
    public int id = 0;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
        mapData = new MapData();
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
    public bool Submit(Placeholder placeholder, MapThing mapThing) {
        int x = (int)(placeholder.rectTransform.anchoredPosition.x / cellSize);
        int y = (int)(placeholder.rectTransform.anchoredPosition.y / cellSize);
        Debug.Log("trying to add to " + x + " " + y);
        if(mapData.Occupied(id, x, y)) return false;
        mapData.AddThing(mapThing, id, x, y);
        return true;
    }
}
