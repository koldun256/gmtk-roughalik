using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    private void Start() {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
}
