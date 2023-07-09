using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCard : Card
{
    public int moneyCost = 1;
    void Start()
    {
        mapThing = new Goblin();
        mapThing.moneyCost = 1;
    }
}
