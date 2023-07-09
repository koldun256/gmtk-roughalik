using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    protected MapCreator mapCreator;
    public MapThing mapThing;
    public Transform originalParent;
    public Transform canvas;
    public TMP_Text costText;
    public RectTransform rectTransform;
    public bool isOnMap = false;
    
    void Awake() {
        mapCreator = GameObject.Find("map_creator").GetComponent<MapCreator>();
        rectTransform = GetComponent<RectTransform>();
        originalParent = transform.parent;
        canvas = GameObject.Find("Canvas").transform;
    }
    
    void Update() {
        if (costText.text == "0") costText.text = mapThing.moneyCost.ToString();
    }

    private void EnterMap() {
        rectTransform.pivot = Vector2.zero;
        mapCreator.roomContainers[mapCreator.activeId].Attach(gameObject);
        isOnMap = true;
    }

    private void ExitMap() {
        rectTransform.parent = canvas;
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.zero;
        rectTransform.pivot = Vector2.one / 2;
        isOnMap = false;
    }

    private bool IsAboveMap(RoomContainerUI room, Vector2 mousePosition) {
        Vector3[] corners = room.GetCorners();
        return  mousePosition.x > corners[0].x &&
                mousePosition.x < corners[2].x &&
                mousePosition.y > corners[0].y &&
                mousePosition.y < corners[2].y;
    }

    private void GoHome() {
        BigMode();
        rectTransform.parent = originalParent;
        transform.parent.gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(true);
    }

    private void TinyMode() {
        costText.gameObject.SetActive(false);
        var cellSize = mapCreator.roomContainers[mapCreator.activeId].cellSize;
        rectTransform.sizeDelta = new Vector2(cellSize, cellSize);
    }

    private void BigMode() {
        costText.gameObject.SetActive(true);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if(!isOnMap) {
            TinyMode();
            rectTransform.pivot = Vector2.one / 2;
            gameObject.transform.parent = canvas;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.zero;
        } else {
            mapCreator.Remove(this);
        }
    }

    public void OnDrag(PointerEventData data) {
        var room = mapCreator.roomContainers[mapCreator.activeId];
        bool isAboveMap = IsAboveMap(room, data.position);
        if(isAboveMap && !isOnMap) { EnterMap(); }
        if(!isAboveMap && isOnMap) { ExitMap(); }

        rectTransform.anchoredPosition = isOnMap
            ? room.SnapPosition(room.TranslatePosition(data.position))
            : data.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if(!isOnMap || !mapCreator.Submit(this)) { GoHome(); }
    }
}