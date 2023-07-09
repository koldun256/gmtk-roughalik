using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCard : Card
{
    void Start()
    {
        mapThing = new Sword();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
