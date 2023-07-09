using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCard : Card
{
    void Start()
    {
        mapThing = new Spear();
        mapThing.moneyCost = -2;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
