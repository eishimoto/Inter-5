using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject insideOfBookMenu;
    [SerializeField] private List<GameObject> insideOfBookMenuButtons;

    [SerializeField] private List<GameObject> maps;
    [SerializeField] private List<GameObject> credits;
    [SerializeField] private List<GameObject> extras;

    [SerializeField] private Image LockImage;
    [SerializeField] private List<GameObject> levelsButtons;
    [SerializeField] private List<Sprite> lockSprite;

    private bool isLock;
    private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClick;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        isLock = true;
        audioSource = GetComponent<AudioSource>();
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(5);
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
        foreach (GameObject button in insideOfBookMenuButtons)
        {
            button.SetActive(true);
        }
    }

    public void Map()
    {
        foreach (GameObject map in maps)
        {
            map.SetActive(true);
        }

        foreach (GameObject credit in credits)
        {
            credit.SetActive(false);
        }

        foreach (GameObject extra in extras)
        {
            extra.SetActive(false);
        }
    }

    public void Credits()
    {
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        foreach (GameObject credit in credits)
        {
            credit.SetActive(true);
        }

        foreach (GameObject extra in extras)
        {
            extra.SetActive(false);
        }
    }

    public void Extras()
    {
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        foreach (GameObject credit in credits)
        {
            credit.SetActive(false);
        }

        foreach (GameObject extra in extras)
        {
            extra.SetActive(true);
        }
    }

    public void UnlockALL()
    {
        if (isLock)
        {
            LockImage.sprite = lockSprite[0];
            levelsButtons[0].SetActive(true);
            levelsButtons[1].SetActive(true);
            levelsButtons[2].SetActive(true);
            isLock = false;
        }
        else
        {
            LockImage.sprite = lockSprite[1];
            levelsButtons[0].SetActive(false);
            levelsButtons[1].SetActive(false);
            levelsButtons[2].SetActive(false);
            isLock = true;
        }
    }

    public void ButtonSound()
    {
        audioSource.PlayOneShot(buttonClick);
    }
}
