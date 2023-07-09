using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    public RoomContainerUI[] roomContainers;
    public MapBuilder mapBuilder;
    private MapData mapData;
    public int activeId = 0;
    private RectTransform rectTransform;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
        mapData = new MapData();
        var id = 0;
        foreach (var roomContainer in roomContainers) {
            roomContainer.id = id++;
            roomContainer.mapData = mapData;
        }
    }
    public void Left() {
        activeId--;
        if(activeId < 0) activeId = 0;
        SetPosition();
    }
    public void Right() {
        activeId++;
        if(activeId > 2) activeId = 2;
        SetPosition();
    }
    private void SetPosition() {
        rectTransform.anchorMin = new Vector2(-activeId, 0);
        rectTransform.anchorMax = new Vector2(3-activeId, 1);
    }
    public void Create() {
        mapBuilder.CreateMap(mapData);
    }
}
