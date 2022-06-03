using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject UI2;
    [SerializeField] private GameObject pausetext;
    private bool isPaused;

    [SerializeField] private GameObject textBox;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        StartCoroutine(OpenTextBox());
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
            Destroy(pausetext);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UI2.SetActive(false);
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

    IEnumerator OpenTextBox()
    {
        yield return new WaitForSeconds(1);
        UI.SetActive(false);
        textBox.SetActive(true);
        pausetext.SetActive(true);
    }
}
