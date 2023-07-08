using System.Collections.Generic;
using UnityEngine;
public class MapThing {}
public class Weapon : MapThing {
    public int damage = 10;
}
public class Sword : Weapon {}
public class Spear : Weapon {}
public class Enemy : MapThing {}
public class Goblin : Enemy {}
public class Slime : Enemy {}
public class Loot : MapThing {}
public class HealingPotion : Loot {}

public class MapData {
    private MapThing[,] mapData;
    public MapData() {
        mapData = new MapThing[6,6];
    }
    public MapThing GetThing(int x, int y) {
        
        MapThing a1 = mapData[0, 0];
        if(a1 is Weapon) {
            Debug.Log((a1 as Weapon).damage);
        }
        return mapData[x, y];
    }
    public bool Occupied(int x, int y) {
        return !(mapData[x, y] is null);
    }
    public void AddThing(MapThing thing, int x, int y) {
        mapData[x, y] = thing;
    }
}