using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCard : Card
{
    void Start()
    {
        mapThing = new Sword();
        mapThing.moneyCost = -1;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
