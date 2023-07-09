using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCard : Card
{
    public int damage;
    public float range;
    public float attackTime;
    void Start()
    {
        var spear = new Spear();
        spear.range = range;
        spear.damage = damage;
        spear.attackTime = attackTime;
        mapThing = spear;
        mapThing.moneyCost = -2;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
