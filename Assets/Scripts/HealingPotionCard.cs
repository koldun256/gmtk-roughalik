using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotionCard : Card
{
    public int moneyCost = -3;
    void Start()
    {
        mapThing = new HealingPotion();
        mapThing.moneyCost = -3;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
