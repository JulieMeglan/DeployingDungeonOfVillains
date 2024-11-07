using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    void Start() {
        if(instance != null) {
            Destroy(this.gameObject);
        }
        
        instance = this;
    
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)){
            Application.Quit();
        }
    }
}
