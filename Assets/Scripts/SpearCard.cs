using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCard : Card
{
    void Start()
    {
        mapThing = new Spear();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
