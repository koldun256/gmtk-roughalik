using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCard : Card
{
    public int damage;
    public float range;
    public float attackTime;
    void Start()
    {
        var sword = new Sword();
        sword.range = range;
        sword.damage = damage;
        sword.attackTime = attackTime;
        mapThing = sword;
        mapThing.moneyCost = -2;
    }
}
