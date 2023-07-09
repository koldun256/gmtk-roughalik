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
        self.transform.position = Vector2.MoveTowards(self.transform.position, target, self.speed*Time.deltaTime);
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
    private WeaponBehavior weapon;
    public float speed = 1;
    void Start() {
        weapon = GetComponent<WeaponBehavior>();
    }
    private void ChangeWeapon(WeaponBehavior newWeapon) {
        Destroy(weapon);
        weapon = newWeapon;
    }
    Decision makeDecision(){
        GameObject target = null;
        float distanceToTarget = 99999f;
        foreach(var child in room.transform){
           if(child.tag=="Enemy"){
               var distance = Vector2.Distance(gameObject.transform.position, child.transform.position);
               if(distanceToTarget>distance){
                    target = child;
                    distanceToTarget = distance;
               }
           }
        }
        if(distanceToTarget != 99999f){
            if(Vector2.Distance(gameObject.transform.position, child.transform.position) <= weapon.range){
                return new AttackDecision();
            }
            else{
                return new MoveDecision(target.position);
            }    
        }
        foreach(var child in room.transform){
           if(child.tag=="Loot"){
               var distance = Vector2.Distance(gameObject.transform.position, child.transform.position);
               if(distanceToTarget>distance){
                    target = child;
                    distanceToTarget = distance;
               }
           }
        }
        if(distanceToTarget != 99999f){
            if(Vector2.Distance(gameObject.transform.position, child.transform.position) <= 0.5f){
                return new LootDecision();
            }
            else{
                return new MoveDecision(target.position);
            }
        }
        return new MoveDecision(new Vector2(7f, 3.5f));
    }

    void Update()
    {
        makeDesicion().Do();
    }
}
