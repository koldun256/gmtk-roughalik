using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCard : Card
{
    void Start()
    {
        mapThing = new Bat();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
