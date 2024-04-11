using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapCreator : MonoBehaviour {
    public RoomContainerUI[] roomContainers;
    private MapData mapData;
    public MapBuilder mapBuilder;
    public int activeId = 0;
    private RectTransform rectTransform;
    public TMP_Text metamoneyIndicator;
    public Button commitButton;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
        mapData = new MapData();
        var id = 0;
        foreach (var roomContainer in roomContainers) {
            roomContainer.id = id++;
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
    private void UpdateMetamoney() {
        var money = MetaMoney.CalculateMoney(mapData);
        metamoneyIndicator.text = money.ToString();
        commitButton.interactable = money >= 0;
    }
    public void Remove(Card card) {
        var cellSize = roomContainers[activeId].cellSize;
        int x = (int)((card.rectTransform.anchoredPosition.x / cellSize) + 0.5f);
        int y = (int)((card.rectTransform.anchoredPosition.y / cellSize) + 0.5f);
        mapData.RemoveThing(activeId, x, y);
        UpdateMetamoney();
    }
    public bool Submit(Card card) {
        var cellSize = roomContainers[activeId].cellSize;
        int x = (int)((card.rectTransform.anchoredPosition.x / cellSize) + 0.5f);
        int y = (int)((card.rectTransform.anchoredPosition.y / cellSize) + 0.5f);
        if(mapData.Occupied(activeId, x, y)) return false;
        mapData.AddThing(card.mapThing, activeId, x, y);
        UpdateMetamoney();
        return true;
    }
}
