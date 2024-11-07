using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private GameObject startButton;


    private void Awake() {
        mainCamera = Camera.main;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)){
            Application.Quit();
        }
    }

    public void ClickToPlay() {
        //  Debug.Log("Button Clicked!");
        startButton.SetActive(false);
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");

    }

} 











