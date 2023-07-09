using UnityEngine;

class MapBuilder : MonoBehaviour {
    public GameObject sword;
    public GameObject slime;
    public GameObject spear;
    public GameObject goblin;
    public GameObject spider;
    public GameObject healingPotion;
    public Room[] rooms;
    void Start() {
        MapData fakeMapData = new MapData();
        fakeMapData.AddThing(new Slime(), 0, 5, 5);
        CreateMap(fakeMapData);
    }
    public void CreateMap(MapData mapData) {
        for (int i = 0;i < 3; i++){
            for (int l = 0;l < 6; l++){
                for (int j = 0;j < 6; j++){
                    MapThing a = mapData.GetThing(i,l,j);
                    if (a is Empty) continue;
                    GameObject newPrefab = null;
                    if (a is Sword){
                        newPrefab = sword;
                    }
                    else if (a is Spear){
                        newPrefab = spear;
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
                    }
                    Debug.Log(i);
                    rooms[i].Place(newPrefab, l, j);
                }
            }
        }
    }
}