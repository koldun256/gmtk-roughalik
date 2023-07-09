using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCard : Card
{
    void Start()
    {
        mapThing = new Slime();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
