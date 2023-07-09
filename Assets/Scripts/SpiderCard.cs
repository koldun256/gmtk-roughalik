using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCard : Card
{
    void Start()
    {
        mapThing = new Spider();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
