using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public MapCreator mapContainerUI;
    public Color color;
    private Placeholder mapPlaceholder;
    protected Vector2 startPosition;
    protected MapThing mapThing;
    void Start() {
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("begin drag");
    }

    public void OnDrag(PointerEventData data) {
        RectTransform rectTransform = GetComponent<RectTransform>();
        RectTransform mapRectTransform = mapContainerUI.gameObject.GetComponent<RectTransform>();
        bool isAboveMap =   data.position.x > mapRectTransform.anchoredPosition.x &&
                            data.position.x < mapRectTransform.anchoredPosition.x + mapRectTransform.rect.width &&
                            data.position.y > mapRectTransform.anchoredPosition.y &&
                            data.position.y < mapRectTransform.anchoredPosition.y + mapRectTransform.rect.height;
        if(isAboveMap && mapPlaceholder is null) {
            mapPlaceholder = mapContainerUI.roomContainers[mapContainerUI.activeId].CreatePlaceholder(color, data.position);
            GetComponent<Image>().color = new Color(0,0,0,0);
        }
        if(!isAboveMap && !(mapPlaceholder is null)) {
            Destroy(mapPlaceholder.gameObject);
            mapPlaceholder = null;
            GetComponent<Image>().color = color;
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
        
    }
}