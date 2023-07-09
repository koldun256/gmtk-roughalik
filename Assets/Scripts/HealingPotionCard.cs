using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotionCard : Card
{
    void Start()
    {
        mapThing = new HealingPotion();
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
