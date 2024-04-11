using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public int health = 200;
    public int location = 0;
    void Start() {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("StartMenu");
    }
}