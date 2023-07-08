using UnityEngine;
class SlimeCard : Card {
    void Start() {
        mapThing = new Slime();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}