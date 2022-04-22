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
    
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSecondLeve2()
    {
        SceneManager.LoadScene(2);
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
}
