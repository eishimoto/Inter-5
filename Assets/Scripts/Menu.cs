using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject insideOfBookMenu;

    [SerializeField] private GameObject leleuMap;
    [SerializeField] private GameObject lisbelaMap;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadFourthLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadFifthLevel()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadSixthLevel()
    {
        SceneManager.LoadScene(6);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    
    public void OpenBook()
    {
        animator.SetBool("openBook", true);
        StartCoroutine(ActivateMenuInsideOfBook());
    }

    IEnumerator ActivateMenuInsideOfBook()
    {
        yield return new WaitForSeconds(1);
        insideOfBookMenu.SetActive(true);
    }

    public void FlipMap()
    {
        leleuMap.SetActive(!leleuMap.activeSelf);
        lisbelaMap.SetActive(!lisbelaMap.activeSelf);
    }

    public void TestButton()
    {
        Debug.Log("TestButton");
    }
}
