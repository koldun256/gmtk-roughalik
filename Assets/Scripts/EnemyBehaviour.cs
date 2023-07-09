using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class EnemyBehaviour : MonoBehaviour
{
    public   float speed = 1f;
    interface Decision
    {
        void Do(EnemyBehaviour self, Room room);
    }
    class MoveDecision : Decision
    {
        public Vector2 target;
        public MoveDecision(Vector2 target)
        {
            this.target = target;
        }
        public void Do(EnemyBehaviour self, Room room)
        {
            self.transform.position = Vector2.MoveTowards(self.transform.position, target, self.speed * Time.deltaTime);
        }
    }
    class AttackDecision : Decision
    {
        public GameObject target;
        public AttackDecision(GameObject target)
        {
            this.target = target;
        }
        public void Do(EnemyBehaviour self, Room room)
        {
            self.weapon.Attack(target);
        }
    }
    public GameObject room;
    public WeaponBehaviour weapon;
    void Start(){
        weapon = GetComponent<WeaponBehaviour>();
        room = gameObject.transform.parent.gameObject;
    }
    Decision MakeDecision()
    {
        foreach (Transform child in room.transform)
        {
            if (child.gameObject.tag == "Player")
            {
                var distance = Vector2.Distance(gameObject.transform.position, child.position);
                if (distance <= weapon.range)
                {
                    return new AttackDecision(child.gameObject);
                }
                else
                {
                    return new MoveDecision(child.position);
                }
            }
        }
        return new MoveDecision(new Vector2(0,0));
    }

    void Update()
    {
        MakeDecision().Do(this, room.GetComponent<Room>());
    }
}
