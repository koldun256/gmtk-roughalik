using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour {
    public Room[] rooms;
    public int activeRoom;
    public Transform camera;
    public GameObject player;

    public void SetRoom(int id) {
        if(id == 3) SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        foreach(Room room in rooms) {
            room.gameObject.SetActive(false);
        }
        rooms[id].gameObject.SetActive(true);
        rooms[id].PlacePlayer(player);
        activeRoom = id;
        camera.position = rooms[id].gameObject.transform.position + Vector3.back;
    }
    void Start() {
        SetRoom(0);
    }
    public void Next() {
        SetRoom(activeRoom + 1);
    }
}
