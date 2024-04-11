using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCard : Card
{
    public int moneyCost = 3;
    void Start()
    {
        mapThing = new Golem();
        mapThing.moneyCost = 3;
    }
}
