using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface Decision {
    void Do(Player self, Room room);
}
class MoveDecision : Decision {
    public Vector2 target;
    public MoveDecision(Vector2 target) {
        this.target = target;
    }
    public void Do(Player self, Room room) {
        self.transform.position = Vector2.MoveTowards(self.transform.position, target, self.speed * Time.deltaTime);
    }
}
class AttackDecision : Decision {
    public GameObject target;
    public AttackDecision(GameObject target){
        this.target = target;
    }
    public void Do(Player self, Room room){
        self.weapon.Attack(target);
    }
}
class LootDecision : Decision {
    public GameObject target;
    public LootDecision(GameObject target){
        this.target = target;
    }
    public void Do(Player self, Room room){
    //TODO
    }
}
public class Player : MonoBehaviour
{
    public GameObject room;
    public WeaponBehaviour weapon;
    public float speed = 1;
    void Start() {
        weapon = GetComponent<WeaponBehaviour>();
    }

    private void ChangeWeapon(WeaponBehaviour newWeapon) {
        Destroy(weapon);
        weapon = newWeapon;
    }

    Decision MakeDecision() {
        GameObject closestEnemy = null;
        float minDistance = 99999f;
        foreach(Transform child in room.transform) {
           if(child.gameObject.tag == "Enemy") {
               var distance = Vector2.Distance(gameObject.transform.position, child.transform.position);
               if(distance < minDistance) {
                    closestEnemy = child.gameObject;
                    minDistance = distance;
               }
           }
        }
        
        if(!(closestEnemy is null)) {
            if(minDistance <= weapon.range) {
                return new AttackDecision(closestEnemy);
            } else {
                return new MoveDecision(closestEnemy.transform.position);
            }
        }

        GameObject closestLoot = null;
        minDistance = 99999f;
        foreach(Transform child in room.transform) {
           if(child.tag == "Loot") {
               var distance = Vector2.Distance(gameObject.transform.position, child.transform.position);
               if(distance < minDistance) {
                    closestLoot = child.gameObject;
                    minDistance = distance;
               }
           }
        }
        if(!(closestLoot is null)) {
            if(minDistance <= 0.5f){
                return new LootDecision(closestLoot);
            } else {
                return new MoveDecision(closestLoot.transform.position);
            }
        }

        return new MoveDecision(new Vector2(7f, 3.5f));
    }

    void Update() {
        MakeDecision().Do(this, room.GetComponent<Room>());
    }
}
