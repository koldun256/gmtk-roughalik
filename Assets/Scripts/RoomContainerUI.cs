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
        cellSize = rectTransform.rect.width / 6;
    }
    public Vector3[] GetCorners() {
        Vector3[] v = new Vector3[4];
        rectTransform.GetWorldCorners(v);
        return v;
    }
    private Vector2 TranslatePosition(Vector2 screenPosition) {
        Vector2 bottomLeft = GetCorners()[0];
        return screenPosition - bottomLeft;
    }
    public Placeholder CreatePlaceholder(Color color, Vector2 screenPosition) {
        Placeholder placeholder = Instantiate(placeholderPrefab, gameObject.transform).GetComponent<Placeholder>();
        placeholder.GetComponent<RectTransform>().sizeDelta = new Vector2(cellSize, cellSize);
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
        int x = (int)((placeholder.rectTransform.anchoredPosition.x / cellSize) + 0.5f);
        int y = (int)((placeholder.rectTransform.anchoredPosition.y / cellSize) + 0.5f);
        Debug.Log("trying to add to " + x + " " + y);
        if(mapData.Occupied(id, x, y)) return false;
        mapData.AddThing(mapThing, id, x, y);
        Debug.Log(mapThing);
        Debug.Log(MetaMoney.CalculateMoney(mapData));
        return true;
    }
}
