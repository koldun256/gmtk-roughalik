using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCard : Card
{
    void Start()
    {
        mapThing = new Bat();
        mapThing.moneyCost = 2;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
