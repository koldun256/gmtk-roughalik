using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaMoney
{
    public static int CalculateMoney(MapData mapData)
    {
        int money = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int l = 0; l < 6; l++)
            {
                for (int j = 0; j < 6; j++)
                {
                    MapThing a = mapData.GetThing(i, l, j);
                    money += a.moneyCost;
                }
            }
        }
        return money;
    }
}
