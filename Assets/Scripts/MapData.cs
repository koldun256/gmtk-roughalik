using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
public class MapThing {
    public int moneyCost;
}
public class Weapon : MapThing {
    public int damage;
    public float range;
    public float attackTime;
}
public class Empty : MapThing {}
public class Sword : Weapon {}
public class Spear : Weapon {}
public class SlimeWeapon: Weapon {}
public class SpiderWeapon : Weapon {}
public class Enemy : MapThing {
    public Weapon weapon;
    public int maxHealth;
}
public class Golem : Enemy
{
    public int maxHealth = 300;
}
public class Bat : Enemy
{
    public int maxHealth = 50;
}
public class Goblin : Enemy {
    public int maxHealth = 70;
}
public class Slime : Enemy {
    public int maxHealth = 40;
}
public class Spider : Enemy {
    public int maxHealth = 90;
}

public class Loot : MapThing {
    public int moneyCost;
}
public class HealingPotion : Loot {}


public class MapData {
    private MapThing[,,] mapData;
    public MapData() {
        mapData = new MapThing[3,6,6];
        for(int i = 0; i < 3; i++) {
            for(int x = 0; x < 6; x++) {
                for(int y = 0; y < 6; y++) {
                    mapData[i, x, y] = new Empty();
                }
            }
        }
    }
    public MapThing GetThing(int i, int x, int y) {
        return mapData[i, x, y];
    }
    public bool Occupied(int i, int x, int y) {
        return !(mapData[i, x, y] is Empty);
    }
    public void AddThing(MapThing thing, int i, int x, int y) {
        mapData[i, x, y] = thing;
    }
    public void RemoveThing(int i, int x, int y) {
        mapData[i, x, y] = new Empty();
    }
}