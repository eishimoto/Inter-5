using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private bool isPaused;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }


    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
