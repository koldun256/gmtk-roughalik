using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    float cellsize = 10f/6f;
    public void Place(GameObject newThing, int x, int y) 
    {
        newThing.transform.parent = gameObject.transform;
        newThing.transform.position = new Vector2(-5+x*cellsize+0.5f,-5+y*cellsize+0.5f);
    }
}
