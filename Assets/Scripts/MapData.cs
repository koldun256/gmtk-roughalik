using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
public class MapThing {}
public class Weapon : MapThing {
    public int damage;
    public float range;
}
public class Empty : MapThing {}
public class Sword : Weapon {
    public new int damage;
    public new float range = 1f;
    public Sword(int damage){
        this.damage = damage;
    }
    public Sword(){
        this.damage = 75;
    }
}
public class Spear : Weapon {
    public new int damage;
    public new float range = 2f;
    public Spear(int damage) { 
        this.damage = damage;
    }
    public Spear(){
        this.damage = 75;
    }
}
public class SlimeWeapon: Weapon{
    public new int damage;
    public new float range = 1f;
    public SlimeWeapon(int damage){
        this.damage = damage;
    }
    public SlimeWeapon(){
        this.damage = 75;
    }
}
public class SpiderWeapon : Weapon{
    public new int damage;
    public new float range = 1f;
    public SpiderWeapon(int damage)
    {
        this.damage = damage;
    }
    public SpiderWeapon()
    {
        this.damage = 75;
    }
}
public class Enemy : MapThing{
    public Weapon weapon;
    public int maxHealth;
    public float attackTime;
}
public class Goblin : Enemy {
    public new int maxHealth = 70;
    public new Weapon weapon = new Spear(40);
    public new float attackTime = 0.5f;
}
public class Slime : Enemy {
    public new int maxHealth = 40;
    public new Weapon weapon = new SlimeWeapon();
    public new float attackTime = 1f;
}
public class Spider : Enemy {
    public new int maxHealth = 90;
    public new Weapon weapon = new SpiderWeapon();
    public new float attackTime = 1f;
}

public class Loot : MapThing {}
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
}