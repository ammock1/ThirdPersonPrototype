using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Button conButton;
    [SerializeField] private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pause menu script running");
        conButton.onClick.AddListener(closeMenu);
        exitButton.onClick.AddListener(exitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            optionsPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void exitGame()
    {
        Application.Quit();
    }

    void closeMenu()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
