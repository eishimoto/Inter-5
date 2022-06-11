using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private string[] textToWrite;
    [SerializeField] private GameObject nextTextBox;
    [SerializeField] private GameObject UI;

    private int index;
    
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject finalButton;


    public bool isLastBox;
    public static bool canFollow;
    public static bool textBoxIsOpen;
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Start()
    {
        index = 0;
        textBox.text = "";
        StartCoroutine(Type());
        canFollow = false;
        textBoxIsOpen = true;
    }
       
    void Update()
    {
        if (textBox.text == textToWrite[index])
        {
            continueButton.SetActive(true);
        }

        if (gameObject.activeSelf.Equals(true))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in textToWrite[index].ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < textToWrite.Length - 1)
        {
            index++;
            textBox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textBox.text = "";
            Cursor.lockState = CursorLockMode.Locked;
            gameObject.SetActive(false);
        }
    }

    IEnumerator CloseTextBox()
    {
        yield return new WaitForSeconds(0.02f);
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
    
    public void CloseTextBoxButton()
    {
       Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if(isLastBox)
        {
            UI.SetActive(true);
            canFollow = true;
            textBoxIsOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        Debug.Log(textBoxIsOpen);
        nextTextBox.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

    }
}
