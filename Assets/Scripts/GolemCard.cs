using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCard : Card
{
    void Start()
    {
        mapThing = new Golem();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
