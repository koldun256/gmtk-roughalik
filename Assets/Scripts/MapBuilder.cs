using UnityEngine;

public class MapBuilder : MonoBehaviour {
    public GameObject sword;
    public GameObject slime;
    public GameObject spear;
    public GameObject goblin;
    public GameObject golem;
    public GameObject spider;
    public GameObject bat;
    public GameObject healingPotion;
    public Room[] rooms;
    public void CreateMap(MapData mapData) {
        for (int i = 0;i < 3; i++){
            for (int l = 0;l < 6; l++){
                for (int j = 0;j < 6; j++){
                    MapThing a = mapData.GetThing(i,l,j);
                    if (a is Empty) continue;
                    GameObject newPrefab = null;
                    if (a is Sword){
                        newPrefab = sword;
                        newPrefab.GetComponent<WeaponLoot>().weapon = a as Weapon;
                    }
                    else if (a is Spear){
                        newPrefab = spear;
                        newPrefab.GetComponent<WeaponLoot>().weapon = a as Weapon;
                    }
                    if (a is Spider){
                        newPrefab = spider;
                    }
                    else if (a is Goblin){
                        newPrefab = goblin;
                    }
                    else if (a is Slime){
                        newPrefab = slime;
                    }
                    else if (a is HealingPotion){
                        newPrefab = healingPotion;
                    } else if (a is Golem) {
                        newPrefab = golem;
                    } else if (a is Bat) {
                        newPrefab = bat;
                    }
                    var newObj = rooms[i].Place(newPrefab, l, j);
                    if(a is Weapon) {
                        newObj.GetComponent<WeaponLoot>().weapon = a as Weapon;
                    }
                }
            }
        }
    }
}