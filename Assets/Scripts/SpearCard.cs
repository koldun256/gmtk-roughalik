using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCard : Card
{
    public int damage;
    public float range;
    public float attackTime;
    public int roomNumber;
    void Start()
    {
        roomNumber = GameObject.Find("Loader").GetComponent<Loader>().location;
        var spear = new Spear();
        for (int i = 0; i < roomNumber; i++)
        {   
            spear.damage = damage*2;
        }
        spear.range = range;
        spear.attackTime = attackTime;
        mapThing = spear;
        mapThing.moneyCost = -2;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
