using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCard : Card
{
    void Start()
    {
        mapThing = new Goblin();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
