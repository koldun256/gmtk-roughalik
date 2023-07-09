using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public Room[] rooms;
    public int activeRoom;
    public Transform camera;

    public void SetRoom(int id) {
        foreach(Room room in rooms) {
            room.gameObject.SetActive(false);
        }
        rooms[id].gameObject.SetActive(true);
        activeRoom = id;
        camera.position = rooms[id].gameObject.transform.position + Vector3.back;
    }
    void Start() {
        SetRoom(0);
    }
    public void Next() {
        
    }
}
