using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    protected MapCreator mapContainerUI;
    public Color color;
    private Placeholder mapPlaceholder;
    protected Vector2 startPosition;
    protected MapThing mapThing;
    public Transform originalParent;
    public Transform canvas;

    void Awake() {
        startPosition = GetComponent<RectTransform>().anchoredPosition;
        mapContainerUI = GameObject.Find("map_creator").GetComponent<MapCreator>();
        originalParent = transform.parent;
        canvas = GameObject.Find("Canvas").transform;
    }
    public void OnBeginDrag(PointerEventData eventData) {
        gameObject.transform.parent = canvas;
        GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
    }

    public void OnDrag(PointerEventData data) {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3[] corners = mapContainerUI.roomContainers[mapContainerUI.activeId].GetCorners();
        bool isAboveMap =   data.position.x > corners[0].x &&
                            data.position.x < corners[2].x &&
                            data.position.y > corners[0].y &&
                            data.position.y < corners[2].y;
        if(isAboveMap && mapPlaceholder is null) {
            mapPlaceholder = mapContainerUI.roomContainers[mapContainerUI.activeId].CreatePlaceholder(color, data.position);
            GetComponent<Image>().color = new Color(0,0,0,0);
        }
        if(!isAboveMap && !(mapPlaceholder is null)) {
            Destroy(mapPlaceholder.gameObject);
            mapPlaceholder = null;
            GetComponent<Image>().color = Color.white;

        }
        GetComponent<RectTransform>().anchoredPosition = data.position;
        if(mapPlaceholder is null) { return; }
        mapContainerUI.roomContainers[mapContainerUI.activeId].SetPlaceholderPosition(mapPlaceholder, data.position);
    }

    public void OnEndDrag(PointerEventData eventData) {
        if(mapPlaceholder is null) {
            GetComponent<RectTransform>().anchoredPosition = startPosition;
        } else {
            if(mapContainerUI.roomContainers[mapContainerUI.activeId].Submit(mapPlaceholder, mapThing)) {
                Destroy(gameObject);
            } else {
                Destroy(mapPlaceholder.gameObject);
                mapPlaceholder = null;
                GetComponent<Image>().color = color;
                GetComponent<RectTransform>().anchoredPosition = startPosition;
            }
        }
        gameObject.transform.parent = originalParent;
        transform.parent.gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(true);
    }
}