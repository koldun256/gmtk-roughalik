using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCard : Card
{
    public int damage;
    public float range;
    public float attackTime;
    public int roomNumber;
    void Start()
    {
        roomNumber = GameObject.Find("Loader").GetComponent<Loader>().location;
        var sword = new Sword();
        for (int i = 0; i < roomNumber; i++)
        {
            sword.damage = damage*2;
        }
        sword.range = range;
        sword.attackTime = attackTime;
        mapThing = sword;
        mapThing.moneyCost = -2;
        startPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
