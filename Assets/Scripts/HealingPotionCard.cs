using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotionCard : Card
{
    public int moneyCost = -2;
    void Start()
    {
        mapThing = new HealingPotion();
        mapThing.moneyCost = -2;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
