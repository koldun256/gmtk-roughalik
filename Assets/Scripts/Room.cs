using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    float cellsize = 10f/6f;
    public GameObject Place(GameObject newPrefab, int x, int y) 
    {
        GameObject newThing = Instantiate(newPrefab, gameObject.transform);
        newThing.transform.localPosition = new Vector3((2*x-5)/12f, (2*y-5)/12f, 0);
        newThing.transform.localScale = Vector3.one / 6;
        return newThing;
    }
    public void PlacePlayer(GameObject player) {
        player.transform.parent = gameObject.transform;
        player.transform.localPosition = new Vector2(-0.417f, 0f);
    }
}
