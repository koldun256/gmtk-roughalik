using System.Collections.Generic;
using UnityEngine;
public class MapThing {}
public class Weapon : MapThing {
    public int damage = 10;
}
public class Empty : MapThing {}
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
        mapData = new MapThing[3,6,6];
        for(int i = 0; i < 3; i++) {
            for(int x = 0; x < 6; x++) {
                for(int y = 0; y < 6; y++) {
                    mapData[x, y] = new Empty();
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
}