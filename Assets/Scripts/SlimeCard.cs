using UnityEngine;
class SlimeCard : Card {
    void Start() {
        mapThing = new Slime();
        mapThing.moneyCost = 1;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}