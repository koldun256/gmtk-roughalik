using UnityEngine;

class MapBuilder : MonoBehaviour {
    public GameObject sword;
    public GameObject slime;
    public GameObject spear;
    public GameObject goblin;
    public GameObject spider;
    public GameObject healingPotion;
    public Room[] room;
    public void CreateMap(MapData mapData) {
        for (int i = 0;i < 3; i++){
            for (int l = 0;l < 6; l++){
                for (int j = 0;j < 6; j++){
                    MapThing a = mapData.GetThing(i,l,j);
                    if (a is Empty) continue;
                    GameObject newThing = null;
                    if (a is Sword){
                        newThing = Instantiate(sword);
                    }
                    else if (a is Spear){
                        newThing = Instantiate(sword);
                    }
                    if (a is Spider){
                        newThing = Instantiate(spider);
                    }
                    else if (a is Goblin){
                        newThing = Instantiate(goblin);
                    }
                    else if (a is Slime){
                        newThing = Instantiate(slime);
                    }
                    else if (a is HealingPotion){
                        newThing = Instantiate(healingPotion); 
                    }
                    room[i].Place(newThing, l, j);
                }
            }
        }
    }
}